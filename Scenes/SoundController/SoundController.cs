using Godot;
using System;

public partial class SoundController : Node
{
	[Export] private AudioStream _mainMenuMusic;
	[Export] private AudioStream _gameMusic;
	[Export] private AudioStream _click;
	[Export] private AudioStream _tileSelected;

	[Export] private AudioStreamPlayer _music;
	[Export] private AudioStreamPlayer _effects;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SignalHub.Instance.Connect(SignalHub.SignalName.OnTileSelected, Callable.From<MemoryTile>(OnTileSelected));
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelSelected, Callable.From<LevelSetting>(OnLevelSelected));
		SignalHub.Instance.Connect(SignalHub.SignalName.OnLevelExit, Callable.From(OnLevelExit));
		SignalHub.Instance.Connect(SignalHub.SignalName.OnButtonPressed, Callable.From(OnButtonPressed));
		OnLevelExit();
	}

    private void OnButtonPressed()
    {
        _effects.Stream = _click;
		_effects.Play();
    }

    private void OnLevelExit()
    {
        _music.Stream = _mainMenuMusic;
		_music.Play();
    }

    private void OnLevelSelected(LevelSetting setting)
    {
        _music.Stream = _gameMusic;
		_music.Play();
    }

    private void OnTileSelected(MemoryTile tile)
    {
        _effects.Stream = _tileSelected;
		_effects.Play();
    }
}
