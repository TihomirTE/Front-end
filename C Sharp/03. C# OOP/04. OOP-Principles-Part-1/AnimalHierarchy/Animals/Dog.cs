namespace AnimalHierarchy
{
    using System;

    public class Dog : Animal, ISound
    {
        public Dog(int age, string name, string sex)
            :base(age, name, sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Dog says \"Bauu\"");
        }
    }
}
