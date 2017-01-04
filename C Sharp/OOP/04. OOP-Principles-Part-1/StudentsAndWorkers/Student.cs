namespace StudentsAndWorkers
{
    public class Student : Human
    {
        public Student(string firstName, string lastName, int grade) 
            : base(firstName, lastName)
        {
            Grade = grade;
        }

        public int Grade { get; private set; }
    }
}
