namespace AnimalHierarchy
{
    public abstract class Animal
    {
        public Animal(int age, string name, string sex)
        {
            Age = age;
            Name = name;
            Sex = sex;
        }

        public int Age { get; private set; }
        public string Name { get; private set; }
        public string Sex { get; private set; }
    }
}
