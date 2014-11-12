namespace ConsoleRPG
{
    using System;
    using ConsoleRPG.Interfaces;

    public class Keyboard
    {
        public System.ConsoleKeyInfo PressedKey;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                this.PressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey();
                }

                this.KeyPressed(this, new EventArgs());
            }
        }

        public event EventHandler KeyPressed;
    }
}