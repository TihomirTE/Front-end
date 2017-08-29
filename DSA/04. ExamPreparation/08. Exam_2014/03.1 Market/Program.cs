using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._1_Market
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var superMarket = new Supermarket();

            var line = Console.ReadLine();

            while (line != "end")
            {
                var command = Command.Parse(line);

                if (command.Name == "add")
                {
                    var product = Product.Parse(command.Arguments);

                    superMarket.Add(product);
                }
                else
                {

                }

                line = Console.ReadLine();
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public static Product Parse(IList<string> productsParts)
        {
            return new Product
            {
                Name = productsParts[0],
                Price = double.Parse(productsParts[1]),
                Type = productsParts[2]
            };
        }

        public int CompareTo(Product other)
        {
            var result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
                if (result == 0)
                {
                    result = this.Type.CompareTo(other.Type);
                }
            }

            return result;
        }
    }

    public class Command
    {
        public string Name { get; set; }

        public IList<string> Arguments { get; set; }

        public static Command Parse(string commandString)
        {
            var commandParts = commandString.Split(' ');
            var listOfStrings = new List<string>();

            var name = commandParts[0];

            for (int i = 0; i < commandParts.Length; i++)
            {
                listOfStrings.Add(commandParts[i]);
            }

            return new Command
            {
                Name = name,
                Arguments = listOfStrings,
            };
        }
    }

    public class Supermarket
    {
        private IDictionary<string, SortedSet<Product>> productsByType;
        private ISet<string> productNames;

        public Supermarket()
        {
            this.productsByType = new Dictionary<string, SortedSet<Product>>();
            this.productNames = new HashSet<string>();
        }

        internal void Add(Product product)
        {
            if (productNames.Contains(product.Name))
            {
                
            }

            if (!productsByType.ContainsKey(product.Type))
            {
                productsByType[product.Type] = new SortedSet<Product>();
            }

            productsByType[product.Type].Add(product);
        }
    }
}
