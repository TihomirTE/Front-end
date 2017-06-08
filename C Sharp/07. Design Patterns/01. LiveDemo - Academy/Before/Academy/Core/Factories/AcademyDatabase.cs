using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Contracts;
using Academy.Models;

namespace Academy.Core.Factories
{
    public class AcademyDatabase : IAcademyDatabase
    {
        private static IAcademyDatabase instanceHolder = new AcademyDatabase();

        private readonly IList<Season> seasons;
        private readonly IList<Student> students;
        private readonly IList<Trainer> trainers;

        public AcademyDatabase()
        {
            this.seasons = new List<Season>();
            this.students = new List<Student>();
            this.trainers = new List<Trainer>();
        }

        public static IAcademyDatabase Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public IList<Season> Seasons
        {
            get
            {
                return this.seasons;
            }
        }

        public IList<Student> Students
        {
            get
            {
                return this.students;

            }
        }

        public IList<Trainer> Trainers
        {
            get
            {
                return this.trainers;

            }
        }
    }
}
