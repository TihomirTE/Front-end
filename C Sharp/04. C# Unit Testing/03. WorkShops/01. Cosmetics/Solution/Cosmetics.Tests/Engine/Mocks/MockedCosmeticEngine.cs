﻿using Cosmetics.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;

namespace Cosmetics.Tests.Engine.Mocks
{
    internal class MockedCosmeticEngine : CosmeticsEngine
    {
        public MockedCosmeticEngine(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser) 
            : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return base.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
