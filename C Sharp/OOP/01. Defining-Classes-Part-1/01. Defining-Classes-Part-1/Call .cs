using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Defining_Classes_Part_1
{
    class Call
    {
        private long? duration;
        private DateTime time;
        private string phoneNumber;

        public Call(long? duration, DateTime time, string phoneNumber)
        {
            this.Duration = duration;
            this.Time = time;
            this.phoneNumber = phoneNumber;
        }
        public DateTime Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }
        public long? Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }
    }
}
