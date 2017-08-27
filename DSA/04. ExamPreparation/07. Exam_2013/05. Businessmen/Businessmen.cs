using System;

namespace _05.Businessmen
{
    public class Businessmen
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var dp = new long[71];
            dp[0] = 1;

            // f(n) += f(oneSidePeople) * f(numberOfBusinessmen - oneSidePeople - 2)
            for (int allPeople = 2; allPeople <= n; allPeople += 2)
            {
                for (int oneSide = allPeople - 2; oneSide >= 0; oneSide -= 2)
                {
                    dp[allPeople] += dp[oneSide] * dp[allPeople - oneSide - 2];
                }
            }

            Console.WriteLine(dp[n]);
        }
    }
}
