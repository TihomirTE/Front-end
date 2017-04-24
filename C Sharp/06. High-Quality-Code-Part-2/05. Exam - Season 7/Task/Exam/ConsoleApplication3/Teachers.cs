namespace ConsoleApplication3
{
    class Teachers
    {
        private string firstName;
        private string lastName;
        private Subjct subject;

        Teachers(string firstName, string lastName, Subjct subject)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.subject = subject;
        }

        public void AddMark(Student teacher, float value)
        {
            var cain = new Mark(this.subject, value);
            teacher
                .marks
                .Add(cain);
        }
    }
}
