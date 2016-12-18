using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Defining_Classes_Part_1
{
    class GSMCallHistoryTest
    {
        // If you want to test GSMTest - first comment the Main method of this class

        static void Main()
        {
            Display samsungDysplay = new Display(16000000, 5.1);
            GSM phone = new GSM("Galaxy S7 ", "Samsung", 1000, samsungDysplay);

            Call currentCall = new Call(850, DateTime.Now, "0888999999");
            phone.AddCall(currentCall);

            currentCall = new Call(1200, DateTime.Now.AddDays(4), "0899777777");
            phone.AddCall(currentCall);

            currentCall = new Call(120, DateTime.Now.AddHours(150), "0877111111");
            phone.AddCall(currentCall);

            foreach (var currCall in phone.callHistory)
            {
                Console.WriteLine("Call: {0}, Phone number: {1}, Call duration: {2}",
                    currCall.Time, currCall.PhoneNumber, currCall.Duration);
            }
            Console.WriteLine("Total price: {0:f2}lv.", phone.CalculateTotalPrice());

            long? maxCallDuration = long.MinValue;
            Call longestCall = new Call(0, DateTime.Now, "0888111111");

            foreach (var currCallCheck in phone.callHistory)
            {
                if (currCallCheck.Duration > maxCallDuration)
                {
                    maxCallDuration = currCallCheck.Duration;
                    longestCall = currCallCheck;
                }
            }

            phone.DeleteCall(longestCall);

            Console.WriteLine("Total price without the longest call is: {0:f2}lv.", phone.CalculateTotalPrice());
            phone.ClearHistory();

        }
    }
}
