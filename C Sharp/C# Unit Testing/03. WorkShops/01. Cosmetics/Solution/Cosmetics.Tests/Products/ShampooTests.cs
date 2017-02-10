using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void ShampooPrint_ShouldReturnStringInTheRerquiredFormat()
        {
            // Arrange
            var shampoo = new Shampoo("Shampoo", "Head", 10M, GenderType.Men, 100, UsageType.EveryDay);

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Head - Shampoo:");
            expectedResult.AppendLine("  * Price: $1000");
            expectedResult.AppendLine("  * For gender: Men");
            expectedResult.AppendLine("  * Quantity: 100 ml");
            expectedResult.AppendLine("  * Usage: EveryDay");

            // Act
            var result = shampoo.Print();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), result);
        }
    }
}
