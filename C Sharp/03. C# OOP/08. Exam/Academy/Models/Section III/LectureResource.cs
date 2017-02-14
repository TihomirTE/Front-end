
namespace Academy.Models.Section_III
{
    using System;
    using System.Text;

    using Academy.Models.Contracts;

    public abstract class LectureResource : ILectureResouce
    {
        private const int MinResourceNameLength = 3;
        private const int MaxResourceNameLength = 15;
        private const int MinUrlNameLength = 5;
        private const int MaxUrlNameLength = 150;

        private string name;
        private string url;

        public LectureResource(Enums.Type type,string name, string url)
        {
            this.Name = name;
            this.Url = url;
            this.Type = type;
        }

        

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < MinResourceNameLength || value.Length > MaxResourceNameLength)
                {
                    throw new ArgumentOutOfRangeException("Resource name should be between 3 and 15 symbols long");
                }

                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }

            set
            {
                if (value.Length < MinUrlNameLength || value.Length > MaxUrlNameLength)
                {
                    throw new ArgumentOutOfRangeException("Resource url should be between 5 and 150 symbols long!");
                }
                this.url = value;
            }
        }

        public Enums.Type Type { get; set; }
        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("*    Resource:");
            result.AppendLine(string.Format("     - Name: {0}", this.Name));
            result.AppendLine(string.Format("     - Url: {0}", this.Url));

            return result.ToString();
        }
    }
}
