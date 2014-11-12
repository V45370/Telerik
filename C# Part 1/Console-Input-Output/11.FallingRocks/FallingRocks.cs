using System;
using System.Collections.Generic;
using System.Threading;


struct Rock
{
    public int x;
    public int y;
    public string c;
    public ConsoleColor color;

}
class Program
{
    private static Random _random = new Random();
    private static ConsoleColor GetRandomConsoleColor()                                     //We make our own random color function 
    {
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
    }

    
    
        
       
    static void PrintOnPosition(int x, int y, string c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);

    }
    


    static void Main()
    {
        char[] visual={'^','@','*','&','+','%','$','#','!','.',';'};                        // We make an array of symbols which will be randomly chosend for rocks
        
        
        int score = 0;
        int playFieldWidth = 30;                                                            //Field width where rocks will fall
        byte livesCount = 5;
        Console.BufferHeight = Console.WindowHeight = 20;                                   //Adjsut console width and height
        Console.BufferWidth = Console.WindowWidth = 50;
        Rock dwarf = new Rock();                                                            //declaring dwarf's position, color and form 
        dwarf.x = 8;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.c = "(0)";
        dwarf.color = ConsoleColor.Blue;
        Random randomGenerator = new Random();
        List<Rock> rocks = new List<Rock>();                                                 //list of rocks

        while (true)
        {
            score++;


            Rock newRock = new Rock();                                                       //making a new rock every loop with a random color and position
            newRock.color = GetRandomConsoleColor();
            newRock.x = randomGenerator.Next(0, playFieldWidth);
            newRock.y = 0;
            newRock.c = char.ToString(visual[randomGenerator.Next(0, 11)]);
            rocks.Add(newRock);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable) Console.ReadKey(true);

                if (pressedKey.Key == ConsoleKey.LeftArrow)                             //Moving the dwarf left and right
                {
                    if (dwarf.x - 1 >= 0)
                    {
                        dwarf.x = dwarf.x - 1;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {

                    if (dwarf.x + 1 < playFieldWidth)
                    {
                        dwarf.x = dwarf.x + 1;
                    }
                }



            }



            List<Rock> newList = new List<Rock>();                                          //making a new list of rocks for a buffer
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];

                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.c = oldRock.c;
                newRock.color = oldRock.color;
                if (newRock.y == dwarf.y && (newRock.x == dwarf.x || newRock.x == dwarf.x + 1 || newRock.x == dwarf.x + 2))  // Checking if we hit a rock
                {
                    livesCount--;                                                                                             // If we hit a rock our lives go down
                    PrintOnPosition(dwarf.x, dwarf.y, "X", ConsoleColor.Red);
                    if (livesCount <= 0)                                                                                      //if we run out of lives ...game over
                    {
                        PrintOnPosition(15, 10, "GAME OVER", ConsoleColor.Red);
                        PrintOnPosition(15, 12, "Press enter to exit", ConsoleColor.Red);
                        Console.ReadLine();
                        return;
                    }
                }
                if (newRock.y < Console.WindowHeight)
                {
                    newList.Add(newRock);
                }




            }
            rocks = newList;


            Console.Clear();


            PrintOnPosition(dwarf.x, dwarf.y, dwarf.c, dwarf.color);                // drawing the dwarf every loop


            foreach (Rock rock in rocks)
            {
                PrintOnPosition(rock.x, rock.y, rock.c, rock.color);                // drawing the rocks
            }
            PrintOnPosition(30, 15, "Lives: " + livesCount, ConsoleColor.White);
            PrintOnPosition(30, 10, "Score: " + score, ConsoleColor.White);
            
            Thread.Sleep(150);



        }

    }
}

