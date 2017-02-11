namespace Cars.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string ShowInffo(string additionalInfo)
        {
            return "Make: " + this.Make + "; Model: " + this.Model + "; Year: " + this.Year + "; Info" + additionalInfo;
        }
    }
}
