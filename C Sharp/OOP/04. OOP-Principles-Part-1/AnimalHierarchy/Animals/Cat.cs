namespace AnimalHierarchy
{
    using System;

    public class Cat: Animal, ISound
    {
        public Cat(int age, string name, string sex)
            :base(age, name, sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Cat says \"Miauu-miauu\"");
        }
    }
}
