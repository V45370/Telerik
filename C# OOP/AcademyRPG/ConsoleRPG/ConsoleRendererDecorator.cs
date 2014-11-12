namespace ConsoleRPG
{
    using System;
    using ConsoleRPG.Interfaces;

    public class ConsoleRendererDecorator : ConsoleRenderer, IRenderer
    {
        private readonly int consoleLength;
        private readonly int paddingLength;
        private readonly string paddingString;

        public ConsoleRendererDecorator(int height, int width) : base(height, width)
        {
            this.consoleLength = Console.WindowWidth;
            this.paddingLength = 3 * this.consoleLength / 100; // 3% of the console width is left/right banner padding
            this.paddingString = new string(' ', paddingLength);
        }

        public void RenderBackground()
        {
            base.RenderBackground();
            this.RenderTopBar();
            this.RenderBotBar();
        }

        private void RenderTopBar()
        {
            Console.SetCursorPosition(0, 0);
            // Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(paddingString);
            // Console.BackgroundColor = ConsoleColor.Black;
         
            string topBannerText = CreateBanner("Academy RPG - Albert Camus Team Version 1.0 Press Esc to Exit");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(topBannerText);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(paddingString);
            // Console.BackgroundColor = ConsoleColor.Black;
        }
        
        private void RenderBotBar()
        {
            Console.SetCursorPosition(0, this.WindowHeight - 1);
            // Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(paddingString);
            // Console.BackgroundColor = ConsoleColor.Black;

            string botBannerText = CreateBanner("Commands: | Inventory i | Status s | Quest List q");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(botBannerText);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            // Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(paddingString.Substring(0, this.paddingLength - 1)); 
        }

        private string CreateBanner(string topBannerText)
        {
            int bannerTextMaxLength = this.consoleLength - 2 * paddingLength;
            int topBannerTextPadding = (bannerTextMaxLength - topBannerText.Length);
            topBannerText = topBannerText.PadLeft(topBannerText.Length + topBannerTextPadding / 2, ' ');
            
            string result = string.Empty;
            
            if (topBannerTextPadding % 2 == 0)
            {
                result = topBannerText.PadRight(topBannerText.Length + topBannerTextPadding / 2, ' ');
            }
            else
            {
                result = topBannerText.PadRight(topBannerText.Length + topBannerTextPadding / 2 + 1, ' ');
            }

            return result;
        }
    }
}