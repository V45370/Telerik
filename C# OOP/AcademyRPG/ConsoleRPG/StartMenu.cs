namespace ConsoleRPG
{
    using System;
    using System.IO;
    using System.Linq;

    public static class StartMenu
    {
        private static string[] gameover =
        {
            @" $$$$$$\   $$$$$$\  $$\      $$\ $$$$$$$$\        $$$$$$\  $$\    $$\ $$$$$$$$\ $$$$$$$\",  
            @"$$  __$$\ $$  __$$\ $$$\    $$$ |$$  _____|      $$  __$$\ $$ |   $$ |$$  _____|$$  __$$\", 
            @"$$ /  \__|$$ /  $$ |$$$$\  $$$$ |$$ |            $$ /  $$ |$$ |   $$ |$$ |      $$ |  $$ |",
            @"$$ |$$$$\ $$$$$$$$ |$$\$$\$$ $$ |$$$$$\          $$ |  $$ |\$$\  $$  |$$$$$\    $$$$$$$  |",
            @"$$ |\_$$ |$$  __$$ |$$ \$$$  $$ |$$  __|         $$ |  $$ | \$$\$$  / $$  __|   $$  __$$<", 
            @"$$ |  $$ |$$ |  $$ |$$ |\$  /$$ |$$ |            $$ |  $$ |  \$$$  /  $$ |      $$ |  $$ |",
            @"\$$$$$$  |$$ |  $$ |$$ | \_/ $$ |$$$$$$$$\        $$$$$$  |   \$  /   $$$$$$$$\ $$ |  $$ |",
            @" \______/ \__|  \__|\__|     \__|\________|       \______/     \_/    \________|\__|  \__|"
        };

        private static string[] arrow =
        {
            @"__   __ ",
            @"\ \  \ \",  
            @" \ \  \ \",
            @"  > >  > >",
            @" / /  / /",
            @"/_/  /_/"
        };

        private static string[] menuText = 
        {
           @" _____  _                 _  ",                        
           @"/  ___|| |               | |",                       
           @"\ `--. | |_   __ _  _ __ | |" ,                      
           @" `--. \| __| / _` || '__|| __|",                      
           @"/\__/ /| |_ | (_| || |   | |",                    
           @"\____/  \__| \__,_||_|    \__|",              
                                                      
                                                      
            @" _   _  _         _   ",                               
            @"| | | |(_)       | |  ",                               
            @"| |_| | _   __ _ | |__   ___   ___   ___   _ __   ___ ",
            @"|  _  || | / _` || '_ \ / __| / __| / _ \ | '__| / _ \",
            @"| | | || || (_| || | | |\__ \| (__ | (_) || |   |  __/",
            @"\_| |_/|_| \__, ||_| |_||___/ \___| \___/ |_|    \___|",
            @"            __/ |" ,                                    
            @"           |___/" ,                                     
            @" _   _        _     "  ,                                
            @"| | | |      | |       " ,                             
            @"| |_| |  ___ | | _ __   ",                             
            @"|  _  | / _ \| || '_ \  ",                             
            @"| | | ||  __/| || |_) | ",                            
            @"\_| |_/ \___||_|| .__/  ",                            
            @"                | |    ",                              
            @"                |_|    ",                               
            @" _____        _  _  ",                                  
            @"|  ___|      (_)| |   ",                               
            @"| |__  __  __ _ | |_  ",                               
            @"|  __| \ \/ /| || __|  ",                              
            @"| |___  >  < | || |_  ",                              
            @"\____/ /_/\_\|_| \__|  "                               
                                                      
                                                      
        };
        private static int menuPosition = 0;
        private static ConsoleKeyInfo key;

        public static void MenuAction()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Draw();
            DrawArrow();
            while (key.Key != ConsoleKey.Escape)
            {

                key = Console.ReadKey();
                if (key.Key.Equals(ConsoleKey.UpArrow))
                {
                    if (menuPosition >= 0 && menuPosition <= 3)
                    {
                        if (menuPosition != 0)
                        {
                            menuPosition--;
                        }
                        Console.Clear();
                        Draw();
                        DrawArrow();
                    }
                }
                if (key.Key.Equals(ConsoleKey.DownArrow))
                {
                    if (menuPosition >= 0 && menuPosition <= 3)
                    {
                        if (menuPosition != 3)
                        {
                            menuPosition++;
                        }
                        Console.Clear();
                        Draw();
                        DrawArrow();
                    }

                }
                if (key.Key.Equals(ConsoleKey.Enter) && menuPosition == 0)
                {

                    StartGame();
                    break;
                }
                if (key.Key.Equals(ConsoleKey.Enter) && menuPosition == 1)
                {
                    HighScore();
                    break;
                }
                if (key.Key.Equals(ConsoleKey.Enter) && menuPosition == 2)
                {
                    Help();
                    break;
                }
                if (key.Key.Equals(ConsoleKey.Enter) && menuPosition == 3)
                {
                    ExitGame();
                    break;
                }

            }
        }

        private static void Draw()
        {

            for (int i = 0; i < menuText.Length; i++)
            {
                Console.SetCursorPosition(30, 5 + i);
                Console.WriteLine(menuText[i]);

            }


        }
        private static void DrawArrow()
        {
            if (menuPosition == 0)
            {
                for (int i = 0; i < arrow.Length; i++)
                {
                    Console.SetCursorPosition(15, 5 + i);
                    Console.WriteLine(arrow[i]);

                }
            }
            else if (menuPosition == 1)
            {
                for (int i = 0; i < arrow.Length; i++)
                {
                    Console.SetCursorPosition(15, 11 + i);
                    Console.WriteLine(arrow[i]);

                }
            }
            else if (menuPosition == 2)
            {
                for (int i = 0; i < arrow.Length; i++)
                {
                    Console.SetCursorPosition(15, 19 + i);
                    Console.WriteLine(arrow[i]);

                }
            }
            else if (menuPosition == 3)
            {
                for (int i = 0; i < arrow.Length; i++)
                {
                    Console.SetCursorPosition(15, 27 + i);
                    Console.WriteLine(arrow[i]);

                }
            }
        }
        private static void StartGame()
        {
            //go to engine run
        }
        private static void HighScore()
        {
            if (!File.Exists(@"scores.txt"))
            {
                StreamWriter sw = new StreamWriter(@"scores.txt");
                sw.WriteLine("Gosho 100");
                sw.WriteLine("Ivan 300");

                sw.Close();
            }
            StreamReader sr = new StreamReader(@"scores.txt");
            using (sr)
            {
                string line = sr.ReadLine();

                if (line == null)
                {
                    Console.WriteLine("No high scores yet!");
                }

                Console.Clear();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
            }

            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();

            MenuAction();
        }
        private static void Help()
        {
            
            string[] help = new string []
{
@"Information and goals:",
@"",
@"There are 3 base knowledge types: ",
@"Desktop and Mobile(DaM), Quality Assurance(QA), Web Developer(WD).",
@"The player can move around the map and can solve riddles, do ",
@"homeworks or attend lectures and he  is rewarded with knowledge or items. ",
@"The player also has a stash where he treasures up items.",
@"Rewards are different items. Once you obtain an item you choose if you want",
@"to equip it or not. The main benefit of the rewards is that they give you ",
@"bonus knowledge. The items can be: paper, pen, book or a laptop. Each item ",
@"has a level (Basic,Advanced,Expert). Depending on how superior one item is ",
@"the more knowledge bonus you get from doing homeworks. ",
@"",
@"Every subject has number of homeworks, lectures, presentations and an exam.",
@"In order to have access to the exam you need to gain knowledge by attending",
@"the lectures, do homeworks and presentations. Each one requests time.",
@"",
@"Game keys:",
@"",
@"UpArrow-Move up",
@"DownArrow-Move down",
@"LeftArrow-Move left",
@"RightArrow-Move right",
@"i-inventory near the chest",
@"q-homeworks",
@"s-player status"
};
            Console.Clear();
            for (int i = 0; i < help.Length; i++)
            {
                Console.SetCursorPosition(5, 5 + i);
                Console.Write(help[i]);
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();

            MenuAction();
        }
        public static void ExitGame()
        {
            Console.Clear();
            string[] gameover =
        {
            @" $$$$$$\   $$$$$$\  $$\      $$\ $$$$$$$$\        $$$$$$\  $$\    $$\ $$$$$$$$\ $$$$$$$\",  
            @"$$  __$$\ $$  __$$\ $$$\    $$$ |$$  _____|      $$  __$$\ $$ |   $$ |$$  _____|$$  __$$\", 
            @"$$ /  \__|$$ /  $$ |$$$$\  $$$$ |$$ |            $$ /  $$ |$$ |   $$ |$$ |      $$ |  $$ |",
            @"$$ |$$$$\ $$$$$$$$ |$$\$$\$$ $$ |$$$$$\          $$ |  $$ |\$$\  $$  |$$$$$\    $$$$$$$  |",
            @"$$ |\_$$ |$$  __$$ |$$ \$$$  $$ |$$  __|         $$ |  $$ | \$$\$$  / $$  __|   $$  __$$<", 
            @"$$ |  $$ |$$ |  $$ |$$ |\$  /$$ |$$ |            $$ |  $$ |  \$$$  /  $$ |      $$ |  $$ |",
            @"\$$$$$$  |$$ |  $$ |$$ | \_/ $$ |$$$$$$$$\        $$$$$$  |   \$  /   $$$$$$$$\ $$ |  $$ |",
            @" \______/ \__|  \__|\__|     \__|\________|       \______/     \_/    \________|\__|  \__|"
        };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine();
            foreach (var line in gameover)
            {
                Console.WriteLine(line);
            }
            System.Threading.Thread.Sleep(3000);
            Environment.Exit(0);
        }
    }
}