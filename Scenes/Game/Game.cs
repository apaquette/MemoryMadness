using Godot;
using System;

public partial class Game : Control
{
	[Export] private GridContainer _tileGrid;
	[Export] private PackedScene _memoryTileScene;
	[Export] private TextureButton _exitButton;
	[Export] private Scorer _scorer;
	[Export] private Label _movesLabel;
	[Export] private Label _pairsLabel;
	private LevelSetting _levelSetting;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelSelected, Callable.From<LevelSetting>(OnLevelSelected));
		SignalHub.Instance.Connect(SignalHub.SignalName.OnMoveMade, Callable.From<int,int>(OnMoveMade));
		_exitButton.Connect("pressed", Callable.From(OnExitButtonPressed));
	}

    private void OnMoveMade(int moves, int pairs)
    {
        // update ui
		_movesLabel.Text = moves.ToString("D3");
		_pairsLabel.Text = $"{pairs}/{_levelSetting.TargetPairs}";
    }

    private void OnExitButtonPressed()
    {
		foreach (Node child in _tileGrid.GetChildren())
		{
			child.QueueFree();
		}
        SignalHub.EmitOnLevelExit();
		SignalHub.EmitOnButtonPressed();
    }
	private void OnLevelSelected(LevelSetting levelSetting)
	{
		_levelSetting = levelSetting;
		OnMoveMade(0,0);
		_scorer.ClearNewGame(levelSetting);
		Texture2D frameImage = ImageManager.GetRandomFrame();
		_tileGrid.Columns = levelSetting.Columns;
		foreach(var item in new LevelDataSelector().GetLevelImages(levelSetting))
		{
			MemoryTile tile = _memoryTileScene.Instantiate<MemoryTile>();
			_tileGrid.AddChild(tile);
			tile.Setup(item, frameImage);
		}
	}
}
