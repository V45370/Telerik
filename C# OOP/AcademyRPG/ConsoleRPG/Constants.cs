using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    public static class Constants
    {
        public const int WINDOW_HEIGHT = 40;
        public const int WINDOW_WIDTH = 100;

        public static readonly Coordinates initialPlayerCoordinates = new Coordinates(19,30);

        public static readonly Coordinates StashCoordinates = new Coordinates(20, 10);

        public static readonly Coordinates IvayloCoordinates = new Coordinates(10, 30);
        public static readonly Coordinates NikiCoordinates = new Coordinates(10, 60);
        public static readonly Coordinates DonchoCoordinates = new Coordinates(30, 30);
        public static readonly Coordinates NakovCoordinates = new Coordinates(30, 60);
        
        public static readonly Coordinates _TESTMountainCoordinates1 = new Coordinates(35, 55);           
        public static readonly Coordinates _TESTMountainCoordinates2 = new Coordinates(4, 40);

        public static readonly Coordinates _TESTLakeCoordinates1 = new Coordinates(30, 8);      
        public static readonly Coordinates _TESTLakeCoordinates2 = new Coordinates(8, 80);
       
        public static readonly Coordinates _TESTTreeCoordinates1 = new Coordinates(6, 11);
        public static readonly Coordinates _TESTTreeCoordinates2 = new Coordinates(16, 23);  
    }
}
