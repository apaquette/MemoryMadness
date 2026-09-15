using System;
using Godot;

public partial class Master : Control
{
	[Export] private Control _main_scene;
	[Export] private Game _game_scene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ShowGame(false);
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelSelected, Callable.From<LevelSetting>(OnLevelSelected));
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelExit, Callable.From(OnLevelExit));
	}

    private void OnLevelExit()
    {
        ShowGame(false);
    }

    private void OnLevelSelected(LevelSetting level_setting)
    {
        ShowGame(true);
    }

	private void ShowGame(bool show)
	{
		_game_scene.Visible = show;
		_main_scene.Visible = !show;
	}
}
