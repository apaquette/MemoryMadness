using Godot;
using System;

public partial class ImageManager : Node
{
	public static ImageManager Instance { get; private set; }
	public TileImagesHolder TileImagesHolder { get; private set; }
	public Godot.Collections.Array<Texture2D> FrameImages {get; private set;}
    public override void _EnterTree()
    {
        TileImagesHolder = GD.Load<TileImagesHolder>("res://Resources/ImageTiles.tres");
		if(TileImagesHolder.TileImages.Count == 0)
		{
			GD.PrintErr("ImageManager no tiles!!!");
		}
		FrameImages =
        [
            GD.Load<Texture2D>("res://Assets/frames/blue_frame.png"),
			GD.Load<Texture2D>("res://Assets/frames/red_frame.png"),
			GD.Load<Texture2D>("res://Assets/frames/green_frame.png"),
			GD.Load<Texture2D>("res://Assets/frames/yellow_frame.png")
		];
    }

	public override void _Ready() => Instance = this;
	public static Texture2D GetRandomImage() => Instance.TileImagesHolder.GetRandom();
	public static Texture2D GetRandomFrame() => Instance.FrameImages.PickRandom();
	public static Texture2D GetAtIndex(int index) => Instance.TileImagesHolder.GetAtIndex(index);
	public static void Shuffle() => Instance.TileImagesHolder.Shuffle();
}
