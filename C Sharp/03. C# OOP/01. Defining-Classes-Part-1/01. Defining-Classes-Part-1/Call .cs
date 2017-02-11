using System;

namespace _01.Defining_Classes_Part_1
{
    class Call
    {
        // fields
        private long? duration;
        private DateTime time;
        private string phoneNumber;

        // constructor
        public Call(long? duration, DateTime time, string phoneNumber)
        {
            this.Duration = duration;
            this.Time = time;
            this.phoneNumber = phoneNumber;
        }

        // properties
        public DateTime Time { get; set; }
       
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

        public long? Duration { get; set; }

    }
}
