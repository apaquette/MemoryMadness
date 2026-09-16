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
	private void OnLevelSelected(LevelSetting levelSetting)
	{
		Texture2D frameImage = ImageManager.GetRandomFrame();
		_tileGrid.Columns = levelSetting.Columns;
		LevelDataSelector levelDataSelector = new();
		foreach(var item in levelDataSelector.GetLevelImages(levelSetting))
		{
			MemoryTile tile = _memoryTileScene.Instantiate<MemoryTile>();
			_tileGrid.AddChild(tile);
			tile.Setup(item, frameImage);
		}
	}
}
