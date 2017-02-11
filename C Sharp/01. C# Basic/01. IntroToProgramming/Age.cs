using System;

namespace Age
{
    class Age
    {
        static void Main()
        {
            var birthdate = Console.ReadLine();
            var currentTime = DateTime.Now.AddMonths(-7);
           
            DateTime birth = Convert.ToDateTime(birthdate, System.Globalization.CultureInfo.InvariantCulture);
            double days = (currentTime - birth).TotalDays;
            int age = (int)days / 365;
            int ageAfter10Years = age + 10;
            Console.WriteLine(age);
            Console.WriteLine(ageAfter10Years);

        }
    }
}
