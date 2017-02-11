namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    public class Category : ICategory
    {
        private const int CategoryMinLength = 2;
        private const int CategoryMaxLength = 15;

        private ICollection<IProduct> productList;
        private string name;

        public Category(string name)
        {
            this.Name = name;
            this.ProductList = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                // Validator.CheckIfStringIsNullOrEmpty

                Validator.CheckIfStringLengthIsValid(
                    value,
                    CategoryMaxLength,
                    CategoryMinLength,
                    String.Format(GlobalErrorMessages.InvalidStringLength,
                    this.GetType().Name + " name", CategoryMinLength, CategoryMaxLength));
                this.name = value;
            }
        }

        public ICollection<IProduct> ProductList {
            get { return this.productList; }
            private set
            {
                this.productList = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            //Validator.CheckIfNull
            this.productList.Add(cosmetics);
        }


        public void RemoveCosmetics(IProduct cosmetics)
        {
            // Validator.CheckIfNull
            if (!this.productList.Contains(cosmetics))
            {
                throw new InvalidOperationException(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }
            this.productList.Remove(cosmetics);
        }

        public string Print()
        {
            string numberOfProducts = (productList.Count == 0) ? "product" : "products";
            string categoryString = string.Format($"{this.Name} category – {productList.Count} {numberOfProducts} in total");

            StringBuilder result = new StringBuilder();
            result.AppendLine(categoryString);

            var sortedProduct = this.productList
                                    .OrderBy(product => product.Brand)
                                    .ThenByDescending(product => product.Price);

            foreach (var product in sortedProduct)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }
    }
}
