using Calculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTests
{
    public class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            // Arrange
            MemCalculator calculator = MakeCalc();

            // Act
            int lastSum = calculator.Sum();

            // Assert
            Assert.AreEqual(0, lastSum);
        }

        [Test]
        public void Add_WhenCalledWithNumber_ShouldIncreaseSum()
        {
            // Arrenge
            MemCalculator calc = MakeCalc();

            // Act 
            calc.Add(10);
            int sum = calc.Sum();

            // Assert
            Assert.AreEqual(10, sum);
        }

        [Test]
        public void Subtract_WhenCalledWithNumber_ShouldDecreaseSum()
        {
            MemCalculator calc = MakeCalc();

            calc.Subtract(5);
            int result = calc.Sum();

            Assert.AreEqual(-5, result);
        }


        // Use factory method to initialize MemCalculator
        private static MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }

}
