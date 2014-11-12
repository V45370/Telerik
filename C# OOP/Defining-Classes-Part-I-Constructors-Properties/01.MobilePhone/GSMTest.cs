using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone;

namespace MobilePhone
{
    
    public class GSMTest
    {
        static void Main()
        {
            GSM[] gsmArray = new GSM[3];
            gsmArray[0] = new GSM("One X", "HTC", 600, "Az");
            gsmArray[1] = new GSM("Galaxy S3", "Samsung", 600, "Ti");
            gsmArray[2] = new GSM("One V", "HTC", 300, "Toi");
            GSM iphone = GSM.IPhone4S;
            Console.WriteLine(gsmArray[0]);
            Console.WriteLine();
            Console.WriteLine(gsmArray[1]);
            Console.WriteLine();
            Console.WriteLine(gsmArray[2]);
            Console.WriteLine();
            Console.WriteLine(iphone);

        }
        

            
           

    }
}
