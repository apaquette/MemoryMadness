using Godot;
using System;

public partial class SignalHub : Node
{
	public static SignalHub Instance { get; private set; }
	[Signal] public delegate void OnTileSelectedEventHandler(MemoryTile memoryTile);
	[Signal] public delegate void OnLevelSelectedEventHandler(LevelSetting levelSetting);
	[Signal] public delegate void OnLevelExitEventHandler();
	[Signal] public delegate void OnMoveMadeEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() => Instance = this;

	public static void EmitOnTileSelected(MemoryTile memoryTile) => Instance.EmitSignal(SignalName.OnTileSelected, memoryTile);
	public static void EmitOnLevelSelected(LevelSetting levelSetting) => Instance.EmitSignal(SignalName.OnLevelSelected, levelSetting);
	public static void EmitOnLevelExit() => Instance.EmitSignal(SignalName.OnLevelExit);
	public static void EmitOnMoveMade(int moves, int pairs) => Instance.EmitSignal(SignalName.OnMoveMade, moves, pairs);
}
