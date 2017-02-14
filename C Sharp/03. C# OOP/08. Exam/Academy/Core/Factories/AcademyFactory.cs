using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Section_I;
using Academy.Models.Section_II;
using Academy.Models.Section_III;
using Academy.Models.Utils.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            return new Student(username, (Track)Enum.Parse(typeof(Track), track));
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            string result = technologies; 
            string[] parts = result.Split(','); 
            IList<string> list = new List<string>(parts);
            return new Trainer(username, list);
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            return new Course(name, int.Parse(lecturesPerWeek), DateTime.Parse(startingDate));
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            return new Lecture(name, DateTime.Parse(date), trainer);
        }

        public ILectureResouce CreateLectureResouce(string type, string name, string url)
        {
            // Use this instead of DateTime.Now if you want any points in BGCoder!!
            var currentDate = DateTimeProvider.Now;

            switch (type)
            {
                case "video":
                    return new VideoResource((Models.Enums.Type)Enum.Parse(typeof(Models.Enums.Type), type), name, url);
                    break;
                case "presentation":
                    new PresentationResource((Models.Enums.Type)Enum.Parse(typeof(Models.Enums.Type), type), name, url);
                    break;
                case "demo":
                    new DemoResource((Models.Enums.Type)Enum.Parse(typeof(Models.Enums.Type), type), name, url);
                    break;
                case "homework":
                    new HomeworkResource((Models.Enums.Type)Enum.Parse(typeof(Models.Enums.Type), type), name, url);
                    break;
                default: throw new ArgumentException("Invalid lecture resource type");
            }

            throw new NotImplementedException("LectureResouce classes not attached to factory.");

        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            // TODO: Implement this
            throw new NotImplementedException("CourseResult class not attached to factory.");
        }
    }
}
