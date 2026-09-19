using Godot;

public partial class MemoryTile : TextureButton
{
	[Export] private TextureRect _frame, _item;

	public Texture2D ItemTexture => _item.Texture;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += OnPressed;
	}

	public bool Matches(MemoryTile memoryTile) => this != memoryTile && memoryTile.ItemTexture == ItemTexture;

	public void KillOnPair()
	{
		ZIndex = 10;
		Disabled = true;
		Tween tween = CreateTween();
		tween.SetParallel(true);
		tween.TweenProperty(this, PropertyName.RotationDegrees.ToString(), 720.0f, 0.5f);
		tween.TweenProperty(this, PropertyName.Scale.ToString(), new Vector2(1.5f,1.5f), 0.5f);
		tween.SetParallel(false);
		tween.TweenInterval(0.5);
		tween.TweenProperty(this, PropertyName.Scale.ToString(), Vector2.Zero, 0.1f);
	}

    private void OnPressed()
    {
		if (Scorer.SelectionEnabled)
		{
        	Reveal(true);
			SignalHub.EmitOnTileSelected(this);
		}
    }

	public void Setup(Texture2D image, Texture2D frame)
	{
		_item.Texture = image;
		_frame.Texture = frame;
	}

    public void Reveal(bool show)
	{
		_frame.Visible = show;
		_item.Visible = show;
	}
}
