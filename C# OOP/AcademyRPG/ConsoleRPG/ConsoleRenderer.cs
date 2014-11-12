namespace ConsoleRPG
{
    using System;
    using System.Collections.Generic;
    using ConsoleRPG.Interfaces;
    using ConsoleRPG.Enums;
    using ConsoleRPG.GameObjects.MapObjects;

    public abstract class ConsoleRenderer : IRenderer
    {
        private int height;
        private int width;
        private char[,] background;
        private IDictionary<char, RenderColorType> colourMapping;
        private RenderColorType backgroundColor;

        public ConsoleRenderer(int windowHeight, int windowWidth, RenderColorType backgroundColor = RenderColorType.Black)
        {
            this.WindowWidth = windowWidth;
            this.WindowHeight = windowHeight;
            this.ConsoleSetUp();
            this.backgroundColor = backgroundColor;
            this.background = new char[windowHeight, windowWidth];
        }

        private void ConsoleSetUp()
        {
            Console.Title = "Academy RPG - Text Version";
            Console.BufferWidth = Console.WindowWidth = this.WindowWidth;
            Console.BufferHeight = Console.WindowHeight = this.WindowHeight;
            Console.CursorVisible = false;
            Console.BackgroundColor = (ConsoleColor)((int)this.backgroundColor);
        }

        public int WindowWidth
        {
            get
            {
                return this.width;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeInts(value);
                this.width = value;
            }
        }

        public int WindowHeight
        {
            get
            {
                return this.height;
            }
            set
            {
                DataValidiryChecker.CheckForNonNegativeInts(value);
                this.height = value;
            }
        }
        
        public void Render(IRenderable item)
        {
            this.InnerDrawer(item, item.GetRenderColorType());
        }

        public void DeleteObject(IRenderable item)
        {
            this.InnerClearer(item);
        }

        public void InitializeMap(Map map)
        {
            this.background = map.Terrain;
            this.colourMapping = map.GetColourMapings();
            this.colourMapping['\0'] = this.backgroundColor;
        }

        public void RenderBackground()
        {
            for (int i = 0; i < this.background.GetLength(0); i++)
            {
                for (int j = 0; j < this.background.GetLength(1); j++)
                {
                    if (this.background[i, j] != '\0')
                    {
                        this.MapRenderer(this.background[i, j]);
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
        }

        private void InnerClearer(IRenderable item)
        {
            var image = item.GetImage();

            int Xcoord = item.TopLeftCoordinates.X;
            int Ycoord = item.TopLeftCoordinates.Y;

            for (int i = 0; i < image.Length; i++)
            {
                Console.SetCursorPosition(Ycoord, Xcoord + i);
                for (int j = 0; j < image[i].Length; j++)
                {
                    if (Ycoord + j > 0 && Xcoord + i > 0 && Ycoord + j < this.WindowWidth && Xcoord + i < this.WindowHeight)
                    {
                        this.MapRenderer(this.background[Xcoord + i, Ycoord + j]);
                    }
                }
            }
        }

        private void MapRenderer(char ch)
        {
            Console.ForegroundColor = (ConsoleColor)((int)this.colourMapping[ch]);
            Console.Write(ch);
            Console.ForegroundColor = (ConsoleColor)((int)(this.backgroundColor));
        }

        private void InnerDrawer(IRenderable item, RenderColorType color)
        {
            var image = item.GetImage();
            var imageColor = color;

            int Xcoord = item.TopLeftCoordinates.X;
            int Ycoord = item.TopLeftCoordinates.Y;

            Console.ForegroundColor = (ConsoleColor)((int)imageColor);

            for (int i = 0; i < image.Length; i++)
            {
                Console.SetCursorPosition(Ycoord, Xcoord + i);
                for (int j = 0; j < image[i].Length; j++)
                {
                    if (Xcoord + i > 0 && Ycoord + j > 0 && Xcoord + i < this.WindowHeight && Ycoord + j < this.WindowWidth)
                    {
                        Console.Write(image[i][j]);
                    }
                }
            }
        }
    }
}