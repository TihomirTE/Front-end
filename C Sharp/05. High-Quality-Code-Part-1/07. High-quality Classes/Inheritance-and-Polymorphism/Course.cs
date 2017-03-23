namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        public const int MinNamesLength = 2;
        public const int MaxNamesLength = 15;

        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.TeacherName = null;
            this.Students = new List<string>();
        }

        public Course(string name, string teacherName)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = new List<string>();
        }

        public Course(string name, string teacherName, IList<string> students)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Length < MinNamesLength || value.Length > MaxNamesLength)
                {
                    throw new ArgumentOutOfRangeException("Name should be between 2 and 15 symbols");
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            internal set
            {
                if (value.Length < MinNamesLength || value.Length > MaxNamesLength)
                {
                    throw new ArgumentOutOfRangeException("TeacherName should be between 2 and 15 symbols");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            internal set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("There is no students in the course");
                }

                this.students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            if (this.Students != null && this.Students.Count > 0)
            {
                result.Append("; Students = ");
                result.Append(this.GetStudentsAsString());
            }

            result.Append(" }");

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}