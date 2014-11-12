namespace ConsoleRPG.GameObjects.MapObjects
{
    using ConsoleRPG.Enums;

    public class Lake : MapObject
    {
        public Lake(int coordX, int coordY) : this(new Coordinates(coordX, coordY))
        {
        }

        public Lake(Coordinates topLeftCoords) : base(topLeftCoords, new string[]
        {
            " ~~~~ ",
            "~~~~~~",
            " ~~~~ ",
        },
        "lake")
        {
        }
        
        public override RenderColorType GetRenderColorType()
        {
            return RenderColorType.Blue;
        }
    }
}