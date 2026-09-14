using Godot;
using System;

public partial class SignalHub : Node
{
	public static SignalHub Instance { get; private set; }
	[Signal] public delegate void OnLevelSelectedEventHandler(LevelSetting level_setting);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	public static void EmitOnLevelSelected(LevelSetting level_setting)
	{
		Instance.EmitSignal(SignalName.OnLevelSelected, level_setting);
	}
}
