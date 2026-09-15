using Godot;
using System;

public partial class Game : Control
{
	[Export] private GridContainer _tileGrid;
	[Export] private PackedScene _memoryTileScene;
	[Export] private TextureButton _exitButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelSelected, Callable.From<LevelSetting>(OnLevelSelected));
		_exitButton.Connect("pressed", Callable.From(OnExitButtonPressed));
	}

    private void OnExitButtonPressed()
    {
		foreach (Node child in _tileGrid.GetChildren())
		{
			child.QueueFree();
		}
        SignalHub.EmitOnLevelExit();
    }
	private void OnLevelSelected(LevelSetting level_setting)
	{
		_tileGrid.Columns = level_setting.Columns;
		for (int i = 0; i < level_setting.TileCount; i++)
		{
			_tileGrid.AddChild(_memoryTileScene.Instantiate<MemoryTile>());
		}
	}
}
