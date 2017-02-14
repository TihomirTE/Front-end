namespace Academy.Models.Section_I
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Academy.Models.Contracts;
    using Academy.Models.Utils.Contracts;
    using Academy.Models.Enums;

    public class Student : User, IStudent, IUser
    {
        public const Track TrackMinimum = Track.Frontend;
        public const Track TrackMaximum = Track.None;

        private Track track;

        public Student(string username, Track track ) 
            : base(username)
        {
            this.Track = track;
            this.CourseResults = new List<ICourseResult>();
        }

        public IList<ICourseResult> CourseResults { get; set; }
        

        public Track Track
        {
            get
            {
                return this.track;
            }

            set
            {
                if (value < TrackMinimum || value > TrackMaximum)
                {
                    throw new ArgumentOutOfRangeException("The provided track is not valid!");
                }

                track = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("* Student:");
            result.AppendLine(string.Format("  - Username: {0}", this.Username));
            result.AppendLine(string.Format("  - Track: {0}", this.Track));
            result.AppendLine(string.Format("  - Course results:"));
            if (this.CourseResults.Count == 0)
            {
                result.AppendLine("* User has no course results!");
            }
            else
            {
                foreach (var course in this.CourseResults)
                {
                    result.AppendLine(course.ToString());
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}
