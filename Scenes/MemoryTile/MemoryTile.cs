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
        Reveal(true);
    }

    private void Reveal(bool show)
	{
		_frame.Visible = show;
		_item.Visible = show;
	}
}
