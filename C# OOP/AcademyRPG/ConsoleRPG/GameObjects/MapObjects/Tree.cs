namespace ConsoleRPG.GameObjects.MapObjects
{
    using System;
    using ConsoleRPG.Enums;

    public class Tree : MapObject
    {
        public Tree(int coordX, int coordY) : this(new Coordinates(coordX, coordY))
        {
        }

        public Tree(Coordinates topLeftCoordinates) : base(topLeftCoordinates,
        new string[]
        {
            "       ",
            "   ^   ",
            "  ^^^  ",
            " ^^^^^ ",
            "^^^^^^^",
        },
        "tree")
        {
        }

        public override RenderColorType GetRenderColorType()
        {
            return RenderColorType.Green;
        }
    }
}