using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone;

namespace GSMCallHistoryTest
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            GSM myPhone = new GSM("One X", "HTC");
            Call myCall1 = new Call("+359 123 123 123", 10);
            Call myCall2 = new Call("+359 123 123 124", 20);
            Call myCall3 = new Call("+359 123 123 125", 30);

            myPhone.AddCall(myCall1);
            myPhone.AddCall(myCall2);
            myPhone.AddCall(myCall3);
            PrintCallHistory(myPhone.GetCallHistory());

            float callPricePerMinute = 0.37f;
            
            Console.WriteLine("Total calls price: {0:C}", myPhone.CalculateTotalPrice(callPricePerMinute));

            int longestCallDuration = 0;
            int longestCallIndex = 0;
            int tempIndex = 0;
            foreach (var call in myPhone.GetCallHistory())
            {
                if (call.Duration > longestCallDuration) longestCallIndex = tempIndex;
                tempIndex++;
            }
            myPhone.DeleteCall(longestCallIndex);
          
            Console.WriteLine("Total calls price: {0:C}", myPhone.CalculateTotalPrice(callPricePerMinute));

            myPhone.ClearCallHistory();
            PrintCallHistory(myPhone.GetCallHistory());
        }

        private static void PrintCallHistory(List<Call> CallHistory)
        {
            if (CallHistory.Count == 0)
            {
                Console.WriteLine("Call history is empty!");
                return;
            }
            Console.WriteLine("Calls in call history:");
            foreach (var call in CallHistory)
            {
                Console.WriteLine(call);
            }

        }
    }
}
