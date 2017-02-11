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
    public class ToothpasteTests
    {
        [Test]
        public void ToothpatsePrint_ShouldReturnStringWithToothpasteDetails()
        {
            var toothpaste = new Toothpaste("Toothpaste", "Tooth", 10M, GenderType.Men, new List<string>() { "tooth", "white" });

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Tooth - Toothpaste:");
            expectedResult.AppendLine("  * Price: $10");
            expectedResult.AppendLine("  * For gender: Men");
            expectedResult.Append("  * Ingredients: tooth, white");

            // Act
            var result = toothpaste.Print();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), result);
        }
    }
}
