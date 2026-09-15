using Godot;

[GlobalClass]
public partial class TileImagesHolder : Resource
{
    [Export] public Godot.Collections.Array<Texture2D> TileImages {get; private set;} = [];
    public TileImagesHolder(){}
    public Texture2D GetRandom() => TileImages.PickRandom();
    public Texture2D GetAtIndex(int index)
    {
        if(TileImages.Count == 0 | index >= TileImages.Count)
        {
            GD.PrintErr("TileImages.Count == 0!! || index >= TileImages.Count!!");
        }
        return TileImages[index];
    }

    public void Shuffle() => TileImages.Shuffle();
}
