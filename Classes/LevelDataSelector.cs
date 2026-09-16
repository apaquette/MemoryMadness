using Godot;
using System;

public class LevelDataSelector
{
	public Godot.Collections.Array<Texture2D> GetLevelImages(LevelSetting levelSetting)
	{
		ImageManager.Shuffle();
		Godot.Collections.Array<Texture2D> images = [];
		for(int i = 0; i < levelSetting.TargetPairs; i++)
		{
			var image = ImageManager.GetAtIndex(i);
			images.Add(image);
			images.Add(image);
		}
		images.Shuffle();
		return images;
	}
}