namespace ConsoleRPG.GameObjects.MapObjects
{
    using System;
    using ConsoleRPG.Interfaces;

    public abstract class MapObject : GameObject, IRenderable
    {
        private readonly string[] image;
        private readonly Coordinates topLeftCoords;

        public MapObject(Coordinates topLeftCoords, string[] image, string name) : base(name)
        {
            this.topLeftCoords = topLeftCoords;
            this.image = image;
        }

        public string[] GetImage()
        {
            return this.image;
        }

        public Coordinates TopLeftCoordinates
        {
            get
            {
                return this.topLeftCoords;
            }
        }

        public abstract Enums.RenderColorType GetRenderColorType();
    }
}