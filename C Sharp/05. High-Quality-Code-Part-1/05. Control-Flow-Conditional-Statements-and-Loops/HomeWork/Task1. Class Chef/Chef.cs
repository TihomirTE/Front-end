namespace Task1.Class_Chef
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = new Potato();
            potato.GetVegetable();

            Carrot carrot = new Carrot();
            carrot.GetVegetable();

            Bowl bowl;

            Peel(potato);
            Peel(carrot);

            bowl = GetBowl();

            Cut(potato);
            Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private void Peel(Vegetable potato)
        {
            throw new NotImplementedException();
        }

        private void Cut(Vegetable potato)
        {
            throw new NotImplementedException();
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException(); 
        }
    }
}
