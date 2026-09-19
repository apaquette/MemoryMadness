using Godot;
using System.Collections.Generic;

public partial class Scorer : Node
{
	public static bool SelectionEnabled { get; private set; } = true;
	[Export] private Timer _revealTimer;
	private List<MemoryTile> _selectedTiles = [];
	private int _movesMade = 0, _pairsMade = 0, _targetPairs = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.Connect(SignalHub.SignalName.OnTileSelected, Callable.From<MemoryTile>(OnTileSelected));
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelExit, Callable.From(OnLevelExit));
		_revealTimer.Timeout += OnRevealTimeout;
	}

    private void OnLevelExit()
    {
        _revealTimer.Stop();
		_selectedTiles.Clear();
    }

    public void ClearNewGame(LevelSetting levelSetting)
	{
		_selectedTiles.Clear();
		SelectionEnabled = true;
		_movesMade = 0;
		_pairsMade = 0;
		_targetPairs = levelSetting.TargetPairs;
	}

    private void OnRevealTimeout()
    {
        foreach(var tile in _selectedTiles)
		{
			tile.Reveal(false);
		}
		_selectedTiles.Clear();
		SelectionEnabled = true;
    }

    private void OnTileSelected(MemoryTile tile)
    {
		if(!SelectionEnabled || _selectedTiles.Contains(tile)) return;
        _selectedTiles.Add(tile);
		
		if(_selectedTiles.Count != 2) return;
		SelectionEnabled = false;
		_revealTimer.Start();
		if (_selectedTiles[0].Matches(_selectedTiles[1]))
		{
			_selectedTiles[0].KillOnPair();
			_selectedTiles[1].KillOnPair();
			_pairsMade++;
		}
		SignalHub.EmitOnMoveMade(++_movesMade, _pairsMade);
    }
}
