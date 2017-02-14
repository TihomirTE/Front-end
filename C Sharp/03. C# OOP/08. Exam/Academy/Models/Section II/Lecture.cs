namespace Academy.Models.Section_II
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Academy.Models.Contracts;

    public class Lecture : ILecture
    {
        private const int MinLectureNameLength = 5;
        private const int MaxLectureNameLength = 30;

        private string name;

        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
            this.Resouces = new List<ILectureResouce>();
        }

        public DateTime Date { get; set; }


        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < MinLectureNameLength || value.Length > MaxLectureNameLength)
                {
                    throw new ArgumentOutOfRangeException("Lecture's name should be between 5 and 30 symbols long!");
                }
                this.name = value;
            }
        }

        public IList<ILectureResouce> Resouces { get; set; }


        public ITrainer Trainer { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("  * Lecture:");
            result.AppendLine(string.Format("   - Name: {0}", this.Name));
            result.AppendLine(string.Format("   - Date:{0}", this.Date));
            result.AppendLine(string.Format("   - Trainer username: {0}", this.Trainer.Username));
            result.AppendLine("   - Resources:");

            if (this.Resouces.Count > 0)
            {
                foreach (var res in this.Resouces)
                {
                    result.Append(res.ToString());
                }
            }
            else
            {
                result.Append("    * There are no resources in this lecture.");
            }

            return result.ToString().TrimEnd();
        }

    }
}
