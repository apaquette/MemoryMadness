using Godot;
using System;

public partial class LevelButton : TextureButton
{
	[Export] private LevelSetting _level_setting;
	[Export] private Label _label;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(_level_setting == null)
		{
			GD.PushError("LevelSetting is null");
			QueueFree();
			return;
		}
		_label.Text = $"{_level_setting}";
	}
}
