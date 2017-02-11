using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MemCalculator
    {
        private int sum = 0;

        public void Add(int number)
        {
            sum += number;
        }

        public void Subtract(int number)
        {
            sum -= number;
        }

        public int Sum()
        {
            int temp = sum;
            sum = 0;
            return temp;
        }
    }
}
