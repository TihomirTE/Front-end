namespace AnimalHierarchy
{
    using System;

    public class Frog: Animal, ISound
    {
        public Frog(int age, string name, string sex)
            :base(age, name, sex)
        {
        }

        public void MakeSound()
        {
            Console.WriteLine("Frog says \"Kwa-kwa\"");
        }
    }
}
