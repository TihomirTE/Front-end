namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Common;

    public class Toothpaste : Product, IToothpaste, IProduct
    {
        private IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) 
            : base(name, brand, price, gender)
        {
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients);
            }
        }

        public override string Print()
        {
            StringBuilder toothpasteResult = new StringBuilder();
            toothpasteResult.AppendLine(base.Print());
            toothpasteResult.Append(string.Format($"  * Ingredients: {string.Join(", ", this.Ingredients)}"));
            return toothpasteResult.ToString();
        }
    }
}
