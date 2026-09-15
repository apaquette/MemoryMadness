using Godot;
using System;

public partial class FrontSprite : TextureRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetRandomImage();
		RunMe();
	}

	private void SetRandomImage()
	{
		Texture = ImageManager.GetRandom();
	}

	private static float GetRandomRotation() => (float)Mathf.DegToRad(GD.RandRange(-360.0, 360.0));

	private static float GetRandomSpinTime() => (float)GD.RandRange(1.0, 2.0);

	private void RunMe()
	{
		Tween tween = CreateTween();
		tween.TweenProperty(
			this, 
			PropertyName.Scale.ToString(), 
			new Vector2(0.1f, 0.1f),
			1.0f
		);
		tween.TweenCallback(Callable.From(SetRandomImage));
		tween.TweenProperty(
			this, 
			PropertyName.Scale.ToString(), 
			new Vector2(1.0f, 1.0f),
			1.0f
		);
		tween.TweenProperty(
			this, 
			PropertyName.Rotation.ToString(), 
			GetRandomRotation(),
			GetRandomSpinTime()
		);
		tween.TweenInterval(0.1);
		tween.TweenCallback(Callable.From(RunMe));
	}
}
