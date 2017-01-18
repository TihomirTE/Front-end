namespace Cosmetics.Products
{
    using System;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Common;

    public abstract class Product : IProduct
    {
        private const int ProductMinLength = 3;
        private const int ProductMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;
       

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                //Validator.CheckIfStringIsNullOrEmpty
                Validator.CheckIfStringLengthIsValid(
                 value,
                 BrandMaxLength,
                 BrandMinLength,
                 String.Format(GlobalErrorMessages.InvalidStringLength,
                 "Product brand", BrandMinLength, BrandMaxLength));
                this.brand = value;
            }
        }

        public GenderType Gender { get; private set; }
        

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                ///Validator.CheckIfStringIsNullOrEmpty
                Validator.CheckIfStringLengthIsValid(
                  value,
                  ProductMaxLength,
                  ProductMinLength,
                  String.Format(GlobalErrorMessages.InvalidStringLength,
                  "Product name", ProductMinLength, ProductMaxLength));
                this.name = value;
            }
        }

        public decimal Price { get; protected set; }
        

        public virtual string Print()
        {
            StringBuilder productResult = new StringBuilder();
            productResult.AppendLine(string.Format($"- {this.Brand} - {this.Name}:"));
            productResult.AppendLine(string.Format($"  * Price: ${this.Price}"));
            productResult.Append(string.Format($"  * For gender: {this.Gender}"));


            return productResult.ToString();
        }
    }
}
