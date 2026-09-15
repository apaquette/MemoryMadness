using Godot;
using System;

public partial class ImageManager : Node
{
	public static ImageManager Instance { get; private set; }
	public TileImagesHolder TileImagesHolder { get; private set; }

    public override void _EnterTree()
    {
        TileImagesHolder = GD.Load<TileImagesHolder>("res://Resources/ImageTiles.tres");
		if(TileImagesHolder.TileImages.Count == 0)
		{
			GD.PrintErr("ImageManager no tiles!!!");
		}
    }

	public override void _Ready()
	{
		Instance = this;
	}

	public static Texture2D GetRandom()
	{
		return Instance.TileImagesHolder.GetRandom();
	}
	public static Texture2D GetAtIndex(int index)
	{
		return Instance.TileImagesHolder.GetAtIndex(index);
	}
	public static void Shuffle()
	{
		Instance.TileImagesHolder.Shuffle();
	}

}
