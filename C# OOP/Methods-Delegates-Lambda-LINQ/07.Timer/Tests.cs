using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _7.Timer
{
    public class Tests
    {
        static void Pesho()
        {
            Console.WriteLine("pesho");
        }
        static void Main()
        {

            Timer timer = new Timer();
            timer.method = Pesho;
            timer.Start(1, 5);
            //FIX IT
        }
    }
}
