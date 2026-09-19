using Godot;
using System.Collections.Generic;

public partial class LevelButton : TextureButton
{
	[Export] private LevelSetting _levelSetting;
	[Export] private Label _label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(!Valid()) return;

		_label.Text = $"{_levelSetting}";
		Pressed += () => SignalHub.EmitOnLevelSelected(_levelSetting);
		Pressed += SignalHub.EmitOnButtonPressed;
	}

	private bool Valid()
	{
		List<string> errors = [];

		if(_levelSetting is null) errors.Add("LevelSetting is null");
		if(_label is null) errors.Add("Label is null");


		if (errors.Count > 0)
		{
			errors.ForEach(GD.PushError);
			QueueFree();
		}

		return errors.Count == 0;
	}
}
