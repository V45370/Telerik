namespace ConsoleRPG.GameObjects.MapObjects
{
    using System;
    using ConsoleRPG;
    using ConsoleRPG.Enums;

    public class Mountain : MapObject
    {
        public Mountain(int coordX, int coordY) : this(new Coordinates(coordX, coordY))
        {
        }

        public Mountain(Coordinates topLeftCoords) : base(topLeftCoords,
        new string[]
        {
            "        ",
            "   mm   ",
            "  mmmm  ",
            " mmmmmm ",
            "mmmmmmmm",
        },
        "mountain")
        {
        }

        public override RenderColorType GetRenderColorType()
        {
            return RenderColorType.DarkGray;
        }
    }
}