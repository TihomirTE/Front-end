namespace Academy.Models.Section_I
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Academy.Models.Contracts;

    public class Course : ICourse
    {
        private const int MinCourseNameLength = 3;
        private const int MaxCourseNameLength = 45;
        private const int MinLectures = 1;
        private const int MaxLectures = 7;

        private string name;
        private int lecuresPerWeek;

        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
        }


        public DateTime EndingDate { get; set; }
        

        public IList<ILecture> Lectures { get; }
        

        public int LecturesPerWeek
        {
            get
            {
                return this.lecuresPerWeek;
            }

            set
            {
                if (value < MinLectures || value > MaxLectures)
                {
                    throw new ArgumentOutOfRangeException("The number of lectures per week must be between 1 and 7!");
                }

                lecuresPerWeek = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < MinCourseNameLength || value.Length > MaxCourseNameLength)
                {
                    throw new ArgumentOutOfRangeException("The name of the course must be between 3 and 45 symbols!");  
                }
                name = value;
            }
        }

        public IList<IStudent> OnlineStudents { get; }
        

        public IList<IStudent> OnsiteStudents { get; }
        

        public DateTime StartingDate { get; set; }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("* Course");
            result.AppendLine(string.Format("  - Name: {0}", this.Name));
            result.AppendLine(string.Format("  - Lectures per week: {0}", this.LecturesPerWeek));
            result.AppendLine(string.Format("  - Starting date: {0}", this.StartingDate));
            result.AppendLine(string.Format("  - Ending date: {0}", this.EndingDate));
            result.AppendLine(string.Format("  - Lectures:"));
            if (Lectures.Count == 0)
            {
                result.AppendLine(string.Format("   * There are no lectures in this course!"));
            }
            return result.ToString();
        } 
    }
}
