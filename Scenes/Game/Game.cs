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
		RemoveTiles();
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelSelected, Callable.From<LevelSetting>(OnLevelSelected));
		_exitButton.Connect("pressed", Callable.From(OnExitButtonPressed));
	}

    private void OnExitButtonPressed()
    {
        SignalHub.EmitOnLevelExit();
    }

    private void RemoveTiles()
	{
		foreach (Node child in _tileGrid.GetChildren())
		{
			_tileGrid.RemoveChild(child);
		}
	}

	private void AddTiles(LevelSetting level_setting)
	{
		_tileGrid.Columns = level_setting.Columns;
		for (int i = 0; i < level_setting.TileCount; i++)
		{
			MemoryTile tile = _memoryTileScene.Instantiate<MemoryTile>();
			_tileGrid.AddChild(tile);
		}
	}

	private void OnLevelSelected(LevelSetting level_setting)
	{
		RemoveTiles();
		AddTiles(level_setting);
	}
}
