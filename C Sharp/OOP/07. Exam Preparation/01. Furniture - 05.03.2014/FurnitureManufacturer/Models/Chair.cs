using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair
    {
        private decimal height;
        private string materialType;
        private string model;
        private decimal price;

        public Chair(string model, MaterialType materialType, decimal price, decimal height, int numberOfLegs)
        {
            this.Model = model;
            this.MaterialType = materialType;
            this.Price = price;
            this.Height = height;
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; protected set; }

        // TODO 

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Heigth: {4}, Legs: {5}",
                this.GetType().Name, this.Model, this.Material, this.Price,
                this.Height, this.NumberOfLegs);
        }

    }
}
