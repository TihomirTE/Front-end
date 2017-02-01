using School.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Models
{
    public class Student : IStudent
    {
        private const int MinStudentNumber = 10000;
        private const int MaxStudentNumber = 99999;

        private string name;
        private int id;

        public Student(string name)
        {
            this.Name = name;
        }

        public Student(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be empty or null");
                }

                this.name = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Unique number have to be between 10000 and 99999");
                }

                this.id = value;
            }
        }
    }
}
