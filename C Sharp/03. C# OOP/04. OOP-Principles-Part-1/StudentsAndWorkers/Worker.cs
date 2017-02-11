namespace StudentsAndWorkers
{
    public class Worker : Human
    {
        public Worker(string firstName, string lastName, int weekSalary,
            int workHoursPerDay, int moneyPerHour) 
            : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
            MoneyPerHour = moneyPerHour;
        }

        public int WeekSalary { get; private set; }
        public int WorkHoursPerDay { get; private set; }
        public int MoneyPerHour { get; private set; }
    }
}
