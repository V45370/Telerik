﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class TenRandom
    {
        /*
         * Write a program that generates and prints to the console 10 random values in the range [100, 200].
        */
        static void Main()
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("({0}) {1}",i+1,rnd.Next(100,200));
            }
        }
    }

