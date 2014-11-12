namespace ConsoleRPG
{
    using System;
    using System.Linq;
    using System.Threading;

    public static class MenuRenderer
    {
        private const int FieldsHeight = 15;
        private const int FieldsWidth = 30;

        public static void RenderMenu(string[] text, string[] description, int selected, int top, int left)
        {
            if (description == null)
            {
                description = new string[] { "" };
            }
            DrawInWindow(text, top, left, selected, "Inventory", FieldsHeight, FieldsWidth);
            DrawInWindow(description, top, left + FieldsWidth, -1, "Description", FieldsHeight, FieldsWidth);
            WriteOnPosition((char)9574, top, left + FieldsWidth);
            WriteOnPosition((char)9577, top + FieldsHeight + 1, left + FieldsWidth);
        }

        public static void RenderTextOnScreen(int left, int top, int sleepDuaration, string text)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(text);
            Thread.Sleep(sleepDuaration);

            ClearScreen(left, top);
        }
        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void OpenInnerMenuWithText(string text, Coordinates playerCoords)
        {
            var prevColor = Console.ForegroundColor;
            var prevBack = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;

            Console.SetCursorPosition(playerCoords.Y, playerCoords.X);
            Console.Write(text);
            Console.SetCursorPosition(0,0);
            Console.ForegroundColor =  prevColor;
            Console.BackgroundColor = prevBack;

            Thread.Sleep(1000);
        }

        public static void ClearScreen(int top, int left)
        {
            // Console.Clear();
            for (int i = 0; i < FieldsHeight; i++)
            {
                for (int j = 0; j < 2 * FieldsWidth; j++)
                {
                    WriteOnPosition(' ', top + i, left + j);
                }
            }

        }

        private static void WriteOnPosition(
            char ch,
            int top = 0,
            int left = 0,
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(ch);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteOnPosition(
            string text,
            int top = 0,
            int left = 0,
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(text);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void DrawInWindow(string[] text, int top = 0, int left = 0, int selected = 0, string name = "", int height = 0, int width = 0)
        {
            if (text == null)
            {
                text = new string[] { "" };
            }
            var windowLength = MaxTextLength(text) + 2;
            DrawTop(top, left, windowLength, name, width);
            DrawText(text, top + 1, left, windowLength, selected, width, height);

            int h = text.Length > height ? text.Length : height;

            DrawBot(top + h + 1, left, windowLength, width);
        }

        private static void DrawTop(int top, int left, int windowLength, string name, int width)
        {
            if (width > 0 && width < windowLength)
            {
                width = windowLength;
            }

            WriteOnPosition('╔', top, left);
            if (name != "")
            {
                name = " " + name.Trim() + " ";
                var toWriteString = name.PadLeft(2, '═').PadRight(width == 0 ? windowLength : width - 1, '═');
                WriteOnPosition(toWriteString, top, left + 1);
            }
            else
            {
                WriteOnPosition(new string('═', windowLength), top, left + 1);
            }
            WriteOnPosition('╗', top, left + width != 0 ? width + left : windowLength + 1);
        }

        private static void DrawText(string[] text, int top, int left, int windowLength, int selected, int width, int height)
        {
            if (width > 0 && width < windowLength)
            {
                width = windowLength;
            }
            int i = 0;
            for (; i < text.Length; i++)
            {
                WriteOnPosition('║', top + i, left);
                if (i == selected)
                {
                    WriteOnPosition(text[i].PadRight(width != 0 ? width - 5 : windowLength, ' '), top + i, left + 2, ConsoleColor.Black, ConsoleColor.Red);
                }
                else
                {
                    WriteOnPosition(text[i].PadRight(width != 0 ? width - 5 : windowLength, ' '), top + i, left + 2);
                }
                WriteOnPosition('║', top + i, left + width != 0 ? width + left : left + windowLength + 1);
            }

            for (; i < height; i++)
            {
                WriteOnPosition('║', top + i, left);
                WriteOnPosition('║', top + i, left + width != 0 ? width + left : windowLength + 1);
            }
        }

        private static void DrawBot(int top, int left, int windowLength, int width)
        {
            if (width > 0 && width < windowLength)
            {
                width = windowLength;
            }

            WriteOnPosition('╚', top, left);

            WriteOnPosition(new string('═', width != 0 ? width - 1 : windowLength), top, left + 1);

            WriteOnPosition('╝', top, left + width != 0 ? width + left : windowLength + 1);
        }

        private static int MaxTextLength(string[] text)
        {
            int max = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Length > max)
                {
                    max = text[i].Length;
                }
            }

            return max;
        }
    }
}