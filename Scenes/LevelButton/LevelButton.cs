using Godot;
using System.Collections.Generic;

public partial class LevelButton : TextureButton
{
	[Export] private LevelSetting _level_setting;
	[Export] private Label _label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(!Valid()) return;

		_label.Text = $"{_level_setting}";
		Pressed += () => SignalHub.EmitOnLevelSelected(_level_setting);
	}

	private bool Valid()
	{
		List<string> errors = [];

		if(_level_setting is null) errors.Add("LevelSetting is null");
		if(_label is null) errors.Add("Label is null");


		if (errors.Count > 0)
		{
			errors.ForEach(GD.PushError);
			QueueFree();
		}

		return errors.Count == 0;
	}
}
