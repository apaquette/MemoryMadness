using Godot;

[GlobalClass]
public partial class LevelSetting : Resource
{
    [Export] public int Rows { get; private set;}
    [Export] public int Columns { get; private set;}
    public int TargetPairs => Rows * Columns / 2;
    public LevelSetting() {}
}
