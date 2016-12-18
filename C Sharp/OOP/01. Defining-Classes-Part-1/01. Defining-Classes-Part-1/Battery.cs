using System;


namespace _01.Defining_Classes_Part_1
{
    public class Battery
    {
        // fields 
        private string model;
        private int? hoursIde;
        private int? hoursTalk;
        private BatteryType? type;

        // constructors
        public Battery()
        {

        }
        public Battery(string model)
        {
            this.model = model;
        }
        public Battery(int? hoursIdle)
        {
            this.hoursIde = hoursIdle;
        }
        public Battery(int? hoursIdle, int?hoursTalk)
        {
            this.hoursIde = hoursIdle;
            this.hoursTalk = hoursTalk;
        }
        public Battery(int? hoursIdle, int? hoursTalk, string model)
        {
            this.hoursIde = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.model = model;
        }

        // properties
        public string Model { get; set; }
        public int? HoursIdle
        {
            get
            {
                return this.hoursIde;
            }
            set
            {
                this.hoursIde = value;
            }
        }
        public int? HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }
        public BatteryType Type { get; set; }

    }
}
