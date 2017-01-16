namespace RangeExeptions
{
    using System;

    public class InvalidExeptionTest
    {
        // check for number range
        public static void IntExceptiopn(int number)
        {
            int min = 1;
            int max = 100;
            
            if (number >= min && number <= max)
            {
                Console.WriteLine("Number is in range.");
            }
            else
            {
                // if number is not in range get the Message method from InvalidRangeException class
                throw new InvalidRangeException<int>(min, max);
            }
        }

        // Check for date exception 
        public static void DateException(DateTime date)
        {
            DateTime min = new DateTime(1980, 01, 01);
            DateTime max = new DateTime(2013, 12, 31);

            if (date.CompareTo(min) > 0 && date.CompareTo(max) < 0)
            {
                Console.WriteLine("Date is in range {0} - {1}", min, max);
            }
            else
            {
                // if Date is not in range get the Message method from InvalidRangeException class
                throw new InvalidRangeException<DateTime>(min, max);
            }
        }

        static void Main()
        {
            try
            {
                Console.Write("Enter a number : ");
                int number = int.Parse(Console.ReadLine());

                IntExceptiopn(number);

                Console.Write("Enter a date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                DateException(date);
                
            }

            catch (InvalidRangeException<int> ire)
            {
                // print the message which was thrown from invalid enter number
                Console.WriteLine(ire.Message);
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                // print the message which was thrown from invalid enter date
                Console.WriteLine(ire.Message);
            }
        }
    }
}