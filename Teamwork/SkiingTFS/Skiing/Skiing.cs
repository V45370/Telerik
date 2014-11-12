using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Skiing
{
    class Skiing
    {
        //Global vars
        public static int doorsSpeed = 10;
        public static int playerScore = 0;
        public static int playerPenalties = 0;
        public static bool stoneHittedGameOver = false;
        public static bool trackHitGameOver = false;
        public static bool threePenalties = false;
        public static int difficultyLevel = 1;
        public static string playerColor = "Black";

        struct skiPlayer
        {
            public int rowPosition;
            public int colPosition;
            public char head;
            public string body;
            public string ski;
        }

        struct door
        {
            public int leftStickRow;
            public int leftStickCol;

            public int rightStickRow;
            public int rightStickCol;
        }
        struct track
        {
            public int leftEdgeCol;
            public int leftEdgeRow;

            public int rightEdgeCol;
            public int rightEdgeRow;

            public char symbol;
        }

        struct Bonus
        {
            public int rowPos;
            public int colPos;
            public char bonusType;
        }


        // Main menu
        static void MainMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Start game");
            Console.WriteLine("2. Difficulty level");
            Console.WriteLine("3. Graphics");
            Console.WriteLine("4. Credits");
            ConsoleKeyInfo choice;
            choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.D1)
            {
                Console.Clear();
            }
            else if (choice.Key == ConsoleKey.D2)
            {
                Console.Clear();
                difficultyLevel = Menus.ChooseDifficulty();
                MainMenu();
            }
            else if (choice.Key == ConsoleKey.D3)
            {
                Console.Clear();
                playerColor = PlayerColorChanger();
                MainMenu();
            }
            else if (choice.Key == ConsoleKey.D4)
            {
                Console.Clear();
                Credits();
                MainMenu();
            }
        }


        // Color of the player
        static string PlayerColorChanger()
        {
            Console.SetCursorPosition(15, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Choose the color of your player:");
            Console.WriteLine("1. Magenta");
            Console.WriteLine("2. Blue");
            Console.WriteLine("3. Red");
            Console.WriteLine("4. Yellow");
            Console.WriteLine("5. Green");
            Console.WriteLine("6. Cyan");
            ConsoleKeyInfo choice;
            choice = Console.ReadKey();

            if (choice.Key == ConsoleKey.D1)
            {
                Console.Clear();
                return "Magenta";
            }
            else if (choice.Key == ConsoleKey.D2)
            {
                Console.Clear();
                return "Blue";
            }
            else if (choice.Key == ConsoleKey.D3)
            {
                Console.Clear();
                return "Red";
            }
            else if (choice.Key == ConsoleKey.D4)
            {
                Console.Clear();
                return "Yellow";
            }
            else if (choice.Key == ConsoleKey.D5)
            {
                Console.Clear();
                return "Green";
            }
            else if (choice.Key == ConsoleKey.D6)
            {
                Console.Clear();
                return "Cyan";
            }
            else
            {
                Console.Clear();
                return "Black";
            }
        }

        static void Credits()
        {
            Console.WriteLine("Created By:");
            Console.WriteLine();
            string yanko = "Yanko Tsigularoff";
            string vasil = "Vasil Bonev";
            string nikolay = "Nikolay Gornakov";
            string stefan = "Stefan Popgeorgiev";
            string stavri = "Stavri Zoichkin";
            string victor = "Victor Draganov";

            for (int i = 0; i < yanko.Length; i++)
            {
                Console.Write(yanko[i]);
                Thread.Sleep(70);
            }
            Console.WriteLine();
            for (int i = 0; i < vasil.Length; i++)
            {
                Console.Write(vasil[i]);
                Thread.Sleep(70);
            }
            Console.WriteLine();
            for (int i = 0; i < nikolay.Length; i++)
            {
                Console.Write(nikolay[i]);
                Thread.Sleep(70);
            }
            Console.WriteLine();
            for (int i = 0; i < stefan.Length; i++)
            {
                Console.Write(stefan[i]);
                Thread.Sleep(70);
            }
            Console.WriteLine();
            for (int i = 0; i < stavri.Length; i++)
            {
                Console.Write(stavri[i]);
                Thread.Sleep(70);
            }
            Console.WriteLine();
            for (int i = 0; i < victor.Length; i++)
            {
                Console.Write(victor[i]);
                Thread.Sleep(70);
            }
            Thread.Sleep(1000);
        }

        
        static string PlayerSkiPositions(byte number)
        {
            string ski = "| |";
            if (number == 0)
            {
                ski = @"\ \";
            }
            else if (number == 1)
            {
                ski = "| |";
            }
            else if (number == 2)
            {
                ski = "/ /";
            }
            else if (number == 3)
            {
                ski = @"/`\";
            }
            return ski;
        }


        static void PrintOnTheScreen(string playerColor, int row, int col, char head, string body, string ski, List<door> doorsToPrint, List<Bonus> bonusesToPrint, List<track> allTrack)
        {
            Console.Clear();

            //Print Ski Player
            ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), playerColor);
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col + 1, row);
            Console.WriteLine(head);
            Console.SetCursorPosition(col, row + 1);
            Console.WriteLine(body);
            Console.SetCursorPosition(col, row + 2);
            Console.WriteLine(ski);

            //Print basic track
            if (EngineTics < 25)
            {
                for (int i = 0; i < 24; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(3, i);
                    Console.WriteLine("|");
                    Console.SetCursorPosition(43, i);
                    Console.WriteLine("|");
                }
            }

            //Print track
            for (int i = 0; i < allTrack.Count ; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(allTrack[i].leftEdgeCol, allTrack[i].leftEdgeRow);
                Console.WriteLine(allTrack[i].symbol);
                Console.SetCursorPosition(allTrack[i].rightEdgeCol, allTrack[i].rightEdgeRow);
                Console.WriteLine(allTrack[i].symbol);
            }

            //Print the doors
            for (int i = 0; i < doorsToPrint.Count; i++)
            {
                if (i % 3 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }


                Console.SetCursorPosition(doorsToPrint[i].leftStickCol - 1, doorsToPrint[i].leftStickRow - 1);
                Console.WriteLine("<");
                Console.SetCursorPosition(doorsToPrint[i].rightStickCol + 1, doorsToPrint[i].rightStickRow - 1);
                Console.WriteLine(">");
                Console.SetCursorPosition(doorsToPrint[i].leftStickCol, doorsToPrint[i].leftStickRow);
                Console.WriteLine("|");
                Console.SetCursorPosition(doorsToPrint[i].rightStickCol, doorsToPrint[i].rightStickRow);
                Console.WriteLine("|");
                Console.SetCursorPosition(doorsToPrint[i].leftStickCol, doorsToPrint[i].leftStickRow - 1);
                Console.WriteLine("|");
                Console.SetCursorPosition(doorsToPrint[i].rightStickCol, doorsToPrint[i].rightStickRow - 1);
                Console.WriteLine("|");


            }

            //Print bonuses
            for (int i = 0; i < bonusesToPrint.Count; i++)
            {
                Console.SetCursorPosition(bonusesToPrint[i].colPos, bonusesToPrint[i].rowPos);
                Console.WriteLine(bonusesToPrint[i].bonusType);
            }
            
            //Print aditional info
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(57, 6);
            Console.WriteLine("Player score {0}:", playerScore);
            Console.SetCursorPosition(57, 7);
            Console.WriteLine("Player penalties {0}:", playerPenalties);
            Console.SetCursorPosition(57, 9);
            Console.WriteLine("Bonuses:");
            Console.SetCursorPosition(57, 10);
            Console.WriteLine("# - stone watch out!");
            Console.SetCursorPosition(57, 11);
            Console.WriteLine("p - reduce penalties");
            Console.SetCursorPosition(57, 12);
            Console.WriteLine("+ - get 10 extra pts");

            if (stoneHittedGameOver)
            {
                Console.SetCursorPosition(20, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("STONE HIT!");
                Console.SetCursorPosition(20, 12);
                Console.WriteLine("GAME OVER!!!");
                ChechIfHighscore(playerScore);
            }

            if (trackHitGameOver)
            {
                Console.SetCursorPosition(20, 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WRONG WAY");
                Console.SetCursorPosition(20, 12);
                Console.WriteLine("GAME OVER!!!");
                ChechIfHighscore(playerScore);
            }

        }

        static door DoorGenerator()
        {
            Random rnd = new Random();
            door current = new door();

            current.leftStickCol = rnd.Next(15, 35);
            current.leftStickRow = 0;

            current.rightStickCol = current.leftStickCol + 6;
            current.rightStickRow = 0;
            return current;
        }

        //variables for TrackGenerator(don't mind them) :D        
        public static bool turn = false;
        public static int forward = 0;
        public static int previousLeftEdgeCol = 3;
        public static int previousRightEdgeCol = 43;
        public static int EngineTics = 0;

        static track TrackGenerator()
        {
            track current = new track();

            if (EngineTics < 24)
            {
                current.leftEdgeCol = 3;
                current.rightEdgeCol = 43;
                current.symbol = '|';


            }
            else
            {
                if (turn == false)
                {

                    current.leftEdgeCol = previousLeftEdgeCol + 1;
                    previousLeftEdgeCol++;
                    current.rightEdgeCol = previousRightEdgeCol + 1;
                    previousRightEdgeCol++;
                    current.symbol = '/';
                    forward++;
                    if (forward == 13)
                    {
                        forward = 0;
                        turn = true;
                    }

                }

                if (turn == true)
                {

                    current.leftEdgeCol = previousLeftEdgeCol - 1;
                    previousLeftEdgeCol--;
                    current.rightEdgeCol = previousRightEdgeCol - 1;
                    previousRightEdgeCol--;
                    current.symbol = '\\';
                    forward++;
                    if (forward == 13)
                    {
                        forward = 0;
                        turn = false;
                    }

                }
            }


            return current;

        }

        static void MoveTrack(List<track> generatedTrack, skiPlayer playerLocation)
        {
            for (int i = 0; i < generatedTrack.Count; i++)
            {

                track trackmove = generatedTrack[i];
                if (playerLocation.colPosition == trackmove.leftEdgeCol && playerLocation.rowPosition == trackmove.leftEdgeRow)
                {
                    trackHitGameOver = true;
                }
                if (playerLocation.colPosition == trackmove.rightEdgeCol && playerLocation.rowPosition == trackmove.rightEdgeRow)
                {
                    trackHitGameOver = true;
                }

                trackmove.leftEdgeRow++;
                trackmove.rightEdgeRow++;
                generatedTrack[i] = trackmove;
            }
        }

        static void MoveDoors(List<door> doorsToMove, skiPlayer playerLocation)
        {
            for (int i = 0; i < doorsToMove.Count; i++)
            {
                door oldDoor = doorsToMove[i];
                oldDoor.leftStickRow++;
                oldDoor.rightStickRow++;
                doorsToMove[i] = oldDoor;

                if (doorsToMove[i].leftStickRow == playerLocation.rowPosition)
                {
                    if (doorsToMove[i].leftStickCol < playerLocation.colPosition && doorsToMove[i].rightStickCol > playerLocation.colPosition)
                    {
                        playerScore++;
                    }
                    else
                    {
                        playerPenalties++;
                    }
                }
            }
        }

        static Bonus BonusGenerator()
        {
            Bonus currentBonus = new Bonus();
            Random rnd = new Random();

            currentBonus.rowPos = 0;
            currentBonus.colPos = rnd.Next(20, 28);

            int bonusType = 0;
            bonusType = rnd.Next(0, 3);

            if (bonusType == 0)
            {
                currentBonus.bonusType = '#';
            }
            else if (bonusType == 1)
            {
                currentBonus.bonusType = '+';
            }
            else
            {
                currentBonus.bonusType = 'p';
            }



            return currentBonus;
        }

        static void MoveBonuses(List<Bonus> allBonuses, skiPlayer playerLocation)
        {
            for (int i = 0; i < allBonuses.Count; i++)
            {
                Bonus oldBonus = allBonuses[i];
                oldBonus.rowPos++;
                allBonuses[i] = oldBonus;

                if (allBonuses[i].rowPos == playerLocation.rowPosition && Math.Abs(allBonuses[i].colPos - playerLocation.colPosition) <= 2)
                {
                    if (allBonuses[i].bonusType == '#')
                    {
                        Bonus clearCurrent = new Bonus();
                        clearCurrent.rowPos = allBonuses[i].rowPos;
                        clearCurrent.colPos = allBonuses[i].colPos;
                        clearCurrent.bonusType = ' ';
                        allBonuses[i] = clearCurrent;
                        stoneHittedGameOver = true;
                    }
                    else if (allBonuses[i].bonusType == 'p')
                    {
                        Bonus clearCurrent = new Bonus();
                        clearCurrent.rowPos = allBonuses[i].rowPos;
                        clearCurrent.colPos = allBonuses[i].colPos;
                        clearCurrent.bonusType = ' ';
                        allBonuses[i] = clearCurrent;

                        if (playerPenalties > 0)
                        {
                            playerPenalties--;
                        }
                    }
                    else
                    {
                        Bonus clearCurrent = new Bonus();
                        clearCurrent.rowPos = allBonuses[i].rowPos;
                        clearCurrent.colPos = allBonuses[i].colPos;
                        clearCurrent.bonusType = ' ';
                        allBonuses[i] = clearCurrent;

                        playerScore += 10;
                    }
                }
            }
        }

        static void Engine()
        {
            skiPlayer myPlayer = new skiPlayer();
            List<door> allDoors = new List<door>(20);
            List<Bonus> allBonuses = new List<Bonus>(20);
            List<track> allTrack = new List<track>(20);

            byte skiPosition = 1;
            myPlayer.rowPosition = 20;
            myPlayer.colPosition = 20;
            myPlayer.head = '@';
            myPlayer.body = @"/|\";
            myPlayer.ski = "";
            int doorRepeater = 10;
            int callBonusSystem = 0;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        myPlayer.colPosition -= 2;
                        skiPosition = 0;
                        myPlayer.ski = PlayerSkiPositions(skiPosition);

                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        myPlayer.colPosition += 2;
                        skiPosition = 2;
                        myPlayer.ski = PlayerSkiPositions(skiPosition);
                    }
                    if (pressedKey.Key == ConsoleKey.DownArrow)
                    {
                        skiPosition = 3;
                        myPlayer.ski = PlayerSkiPositions(skiPosition);
                    }
                    if (pressedKey.Key == ConsoleKey.Escape)
                    {                        
                        Console.SetCursorPosition(20, 10);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Exit Game? Y/N");
                        
                        pressedKey = Console.ReadKey();
                        if (pressedKey.Key == ConsoleKey.Y)
                        {
                            return;
                        }                        
                    }
                }
                else
                {
                    skiPosition = 1;
                    myPlayer.ski = PlayerSkiPositions(skiPosition);
                }

                allTrack.Add(TrackGenerator());
                MoveTrack(allTrack, myPlayer);
                if (allTrack[0].leftEdgeRow == 24)
                {
                    allTrack.RemoveAt(0);
                }
                if (doorRepeater == doorsSpeed)
                {
                    allDoors.Add(DoorGenerator());
                    doorRepeater = 0;
                }
                doorRepeater++;

                MoveDoors(allDoors, myPlayer);

                if (allDoors[0].leftStickRow == 24)
                {
                    allDoors.RemoveAt(0);
                }

                if (callBonusSystem == 0)
                {
                    allBonuses.Add(BonusGenerator());
                }
                callBonusSystem++;

                if (callBonusSystem == 17)
                {
                    callBonusSystem = 0;
                }

                MoveBonuses(allBonuses, myPlayer);

                if (allBonuses[0].rowPos == 24)
                {
                    allBonuses.RemoveAt(0);
                }

                EngineTics++;
                PrintOnTheScreen(playerColor, myPlayer.rowPosition, myPlayer.colPosition, myPlayer.head, myPlayer.body, myPlayer.ski, allDoors, allBonuses, allTrack);
                Thread.Sleep(200/difficultyLevel); //difficultyLevel is an integer number(1, 2 or 3, depending of users choice)

                if (stoneHittedGameOver)
                {
                    return;
                }
                if (trackHitGameOver)
                {
                    return;
                }
                if (playerPenalties >= 3)
                {
                    Console.SetCursorPosition(20, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Too much penalties!" );
                    Console.SetCursorPosition(20, 11);
                    Console.WriteLine("GAME OVER!!!");
                    ChechIfHighscore(playerScore);
                    
                    return;
                }
            }
        }

        static void LoadIntro()
        {
            try
            {
                StreamReader readTeamName = new StreamReader("../../input.txt");
                Console.ForegroundColor = ConsoleColor.Red;
                using (readTeamName)
                {
                    string line;
                    while ((line = readTeamName.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                Thread.Sleep(3000);
                Console.Clear();
                StreamReader readGameName = new StreamReader("../../gamenameN.txt");
                Console.ForegroundColor = ConsoleColor.Red;
                using (readGameName)
                {
                    string line;
                    while ((line = readGameName.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
                Console.ReadKey();
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.GetType());
            }
            catch(FileNotFoundException exc)
            {
                Console.WriteLine(exc.GetType());
            }
                
        }

       static void ChechIfHighscore(int points)
        {
            Thread.Sleep(1500);
            StreamReader readHighscores = new StreamReader("../../textfiles/highscores.txt");
            List<string> top3= new List<string>();

            string line;
            while ((line = readHighscores.ReadLine()) != null)
            {
                int topScores = int.Parse(line.Split()[0]);
                if (points > topScores)
                {
                    PrintCongratsAndPlace(top3.Count+1);
                    string name = SignPlayer();
                    top3.Add(String.Format("{0} {1}",points,name));
                    points = 0;
                }
                top3.Add(line);
            }
            readHighscores.Close();
            StreamWriter assignHighscores = new StreamWriter("../../textfiles/highscores.txt");
            for (int i = 0; i < 3; i++)
            {
                assignHighscores.WriteLine(top3[i]);
            }
            assignHighscores.Close();
            PrintHighScores();

        }

       static void PrintHighScores()
       {
           Console.BackgroundColor = ConsoleColor.Black;
           Console.Clear();
           StreamReader readHighscores = new StreamReader("../../textfiles/highscores.txt");
           string line;
           int place = 1;
           Console.SetCursorPosition(20, 9);
           Console.WriteLine("HIGHSCORES: ");
           while ((line = readHighscores.ReadLine()) != null)
           {
               string[] getLine = line.Split();
               Console.SetCursorPosition(20, 10 + place);
               Console.WriteLine("{0}. {1} - {2} points",place,getLine[1],getLine[0]);
               place++;
           }
           readHighscores.Close();
           Thread.Sleep(1500);
       }

       static string SignPlayer()
       {
           Console.Clear();
           Console.ForegroundColor = ConsoleColor.Red;
           Console.SetCursorPosition(20, 8);
           Console.Write("Enter your name: ");
           string name = Console.ReadLine();
           return name;
       }

        static void PrintCongratsAndPlace(int place)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            StreamReader congrat = new StreamReader("../../textfiles/congrats.txt");
            Console.ForegroundColor = ConsoleColor.Red;
            using (congrat)
            {
                string line;
                while ((line = congrat.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
            if (place == 1) Print1stPlace();
            if (place == 2) Print2ndPlace();
            if (place == 3) Print3rdPlace();
            Thread.Sleep(3000);
        }
        static void Print1stPlace()
        {
            Console.SetCursorPosition(6, 12);
            StreamReader first = new StreamReader("../../textfiles/1stplace.txt");
            Console.ForegroundColor = ConsoleColor.Red;
            using (first)
            {
                string line;
                while ((line = first.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        static void Print2ndPlace()
        {
            Console.SetCursorPosition(6, 12);
            StreamReader first = new StreamReader("../../textfiles/2ndplace.txt");
            Console.ForegroundColor = ConsoleColor.Red;
            using (first)
            {
                string line;
                while ((line = first.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        static void Print3rdPlace()
        {
            Console.SetCursorPosition(6, 12);
            StreamReader first = new StreamReader("../../textfiles/3rdplace.txt");
            Console.ForegroundColor = ConsoleColor.Red;
            using (first)
            {
                string line;
                while ((line = first.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        static void Main()
        {
            Console.Title = "WinterSports 2014 - Skiing";
            Console.BufferHeight = Console.WindowHeight;
            LoadIntro();
            
            while (true) 
            {
                MainMenu();
                Console.BackgroundColor = ConsoleColor.White;
                Engine();
                if (Menus.PlayAgain()) // Endless while breaks if user chooses not to restart game.
                {
                    playerPenalties = 0;
                    playerScore = 0;
                    stoneHittedGameOver = false;
                    trackHitGameOver = false;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
class Menus
{
    
    public static int ChooseDifficulty() //Prints a menu for choosing difficulty and assingns global var difficultyLevel.
    {
        Console.Clear();
        StreamReader diffMenu = new StreamReader("../../textfiles/difficulty.txt");
        Console.ForegroundColor = ConsoleColor.Red;
        using (diffMenu)
        {
            string line;
            while ((line = diffMenu.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        int level = 2;
        while (true)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                if (level > 1) level--;
                PrintLevel(level);
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                if (level < 3) level++;
                PrintLevel(level);
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                return level;
            }
        }
    }
    static void PrintLevel(int x)
    {
        if (x == 1) PrintEasy();
        if (x == 2) PrintNormal();
        if (x == 3) PrintHard();
    }
    static void PrintEasy()
    {
        Console.SetCursorPosition(0, 8);
        StreamReader again = new StreamReader("../../textfiles/difficultyEasy.txt");
        Console.ForegroundColor = ConsoleColor.Red;
        using (again)
        {
            string line;
            while ((line = again.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
    static void PrintNormal()
    {
        Console.SetCursorPosition(0, 8);
        StreamReader again = new StreamReader("../../textfiles/difficultyNormal.txt");
        Console.ForegroundColor = ConsoleColor.Red;
        using (again)
        {
            string line;
            while ((line = again.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
    static void PrintHard()
    {
        Console.SetCursorPosition(0, 8);
        StreamReader again = new StreamReader("../../textfiles/difficultyHard.txt");
        Console.ForegroundColor = ConsoleColor.Red;
        using (again)
        {
            string line;
            while ((line = again.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
   public static bool PlayAgain()//Gives the user an option to restart game, and again choose difficulty. 
    {
        Thread.Sleep(3000);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Clear();
        StreamReader again = new StreamReader("../../textfiles/playagain.txt");
        Console.ForegroundColor = ConsoleColor.Red;
        using (again)
        {
            string line;
            while ((line = again.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        bool yes = true;
        while (true)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                PrintYes();
                yes = true;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                PrintNo();
                yes = false;
            }
            else if (pressedKey.Key == ConsoleKey.Enter)
            {
                if (!yes) Environment.Exit(0);
                if (yes) break;
            }
        }
        return yes;
    }
    static void PrintYes()
    {
        Console.SetCursorPosition(0, 11);
        StreamReader again = new StreamReader("../../textfiles/playagainYes.txt");
        Console.ForegroundColor = ConsoleColor.Red;
        using (again)
        {
            string line;
            while ((line = again.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
    static void PrintNo()
    {
        Console.SetCursorPosition(0, 11);
        StreamReader again = new StreamReader("../../textfiles/playagainNo.txt");
        Console.ForegroundColor = ConsoleColor.Red;
        using (again)
        {
            string line;
            while ((line = again.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}