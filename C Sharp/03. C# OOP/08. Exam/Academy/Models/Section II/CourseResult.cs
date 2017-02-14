namespace Academy.Models.Section_II
{
    using System;

    using Academy.Models.Utils.Contracts;
    using Academy.Models.Contracts;
    using Academy.Models.Enums;
    using System.Text;

    public class CourseResult :  ICourseResult
    {
        private const float MinExamPoints = 0;
        private const float MaxExamPoints = 1000;
        private const float MinCoursePoints = 0;
        private const float MaxCoursePoints = 125;

        private float examPoints;
        private float coursePoints;
        private Grade grade;

        public CourseResult(ICourse course, float coursePoints, float examPoints, Grade grade)
        {
            this.Course = course;
            this.CoursePoints = coursePoints;
            this.ExamPoints = examPoints;
            this.Grade = grade;
        }

        public ICourse Course { get; private set; }
        

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            private set
            {
                if (value < MinCoursePoints || value > MaxCoursePoints)
                {
                    throw new ArgumentOutOfRangeException("Course result's course points should be between 0 and 125!");
                }
                coursePoints = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            private set
            {
                if (value < MinExamPoints || value > MaxExamPoints)
                {
                    throw new ArgumentOutOfRangeException("Course result's exam points should be between 0 and 1000!");
                }
                examPoints = value;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if (this.ExamPoints < 30 || this.CoursePoints < 45)
                {
                    grade = Grade.Failed;
                }
                if (this.ExamPoints >= 65 || this.CoursePoints >= 75)
                {
                    grade = Grade.Excellent;
                }
                if (this.ExamPoints >= 30 || this.CoursePoints >= 45)
                {
                    grade = Grade.Passed;
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("  * {0}: Points - {1}, Grade - {2}", this.Course.Name, this.CoursePoints, this.Grade));
            return result.ToString().TrimEnd();

        }
    }
}
