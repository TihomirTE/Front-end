namespace AnimalHierarchy
{
    using System;
    using System.Linq;

    public class AverageAge
    {
        public static void Main()
        {
            Dog[] dogs =
            {
                new Dog (2, "Rex", "male"),
                new Dog (12, "Balkan", "male"),
                new AnimalHierarchy.Dog (5, "Canka", "female")
            };

            Cat[] cats =
            {
                new Kittens(1, "Moli"),
                new Tomcat(14, "Bobi")
            };

            Frog[] frogs =
            {
                new Frog(3, "Kiril", "male"),
                new Frog(2, "Penka", "female")
            };

            Console.WriteLine("Dogs - average age: " + GroupAge(dogs));
            Console.WriteLine("Cats - average age: " + GroupAge(cats));
            Console.WriteLine("Frogs - average age: " + GroupAge(frogs));
        }

        public static int GroupAge(Animal[] animals)
        {
            var groupAge = (from animal in animals
                         select animal.Age).Sum();

            return groupAge / animals.Length;
        }
    }
}
