namespace ConsoleRPG.GameObjects.MapObjects
{
    using System;
    using System.Collections.Generic;
    using ConsoleRPG.Enums;
    
    public class Map
    {
        private readonly List<ConsoleRPG.Interfaces.IRenderable> mapObjects;

        private char[,] terrain;

        Dictionary<char, RenderColorType> colourMapping;

        public Map(int width, int height)
        {
            this.mapObjects = new List<ConsoleRPG.Interfaces.IRenderable>();
            this.terrain = new char[width, height];
            this.colourMapping = new Dictionary<char, RenderColorType>();

            this.GenerateTestWorld();
        }

        public char[,] Terrain
        {
            get
            {
                this.AddList(this.mapObjects);
                return this.terrain;
            }
        }

        private void Add(ConsoleRPG.Interfaces.IRenderable obj)
        {
            var coords = obj.TopLeftCoordinates;
            var obBody = obj.GetImage();

            for (int i = 0; i < obBody.Length; i++)
            {
                for (int j = 0; j < obBody[i].Length; j++)
                {
                    this.terrain[coords.X + i, coords.Y + j] = obBody[i][j];
                    if (!this.colourMapping.ContainsKey(obBody[i][j]))
                    {
                        this.colourMapping[obBody[i][j]] = obj.GetRenderColorType();
                    }
                }
            }
        }

        public Dictionary<char, ConsoleRPG.Enums.RenderColorType> GetColourMapings()
        {
            return this.colourMapping;
        }

        public void AddList(IList<ConsoleRPG.Interfaces.IRenderable> list)
        {
            foreach (var item in list)
            {
                this.Add(item);
            }
        }

        public void GenerateTestWorld()
        {
            this.mapObjects.Add(new Lake(Constants._TESTLakeCoordinates1));
            this.mapObjects.Add(new Lake(Constants._TESTLakeCoordinates2));

            this.mapObjects.Add(new Mountain(Constants._TESTMountainCoordinates1));
            this.mapObjects.Add(new Mountain(Constants._TESTMountainCoordinates2));

            this.mapObjects.Add(new Tree(Constants._TESTTreeCoordinates1));

            this.AddList(this.mapObjects);
        }
    }
}