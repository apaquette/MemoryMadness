using Godot;
using System;

public partial class GameOverUi : PanelContainer
{
	[Export] private Label _movesLabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelExit, Callable.From(Hide));
		SignalHub.Instance.Connect(SignalHub.SignalName.OnGameOver, Callable.From<int>(OnGameOver));
	}

    private void OnGameOver(int moves)
    {
        _movesLabel.Text = $"You took {moves:000} moves! Well done :)";
		Show();
    }
}
