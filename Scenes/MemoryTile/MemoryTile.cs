using Godot;

public partial class MemoryTile : TextureButton
{
	[Export] private TextureRect _frame, _item;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += OnPressed;
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
