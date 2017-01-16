
namespace Cosmetics.Products
{
    using System.Collections.Generic;
    using System.Linq;

    using Cosmetics.Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private readonly IList<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }
        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.products.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public decimal TotalPrice()
        {
            return this.products.Sum(pr => pr.Price);
        }
    }
}
