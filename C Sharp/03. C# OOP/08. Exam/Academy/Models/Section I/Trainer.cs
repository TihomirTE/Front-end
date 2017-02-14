namespace Academy.Models.Section_I
{
    using System.Collections.Generic;
    using System.Text;

    using Academy.Models.Contracts;

    public class Trainer : User, ITrainer, IUser
    {
        public Trainer(string username, IList<string> technology) 
            : base(username)
        {
            this.Technologies = technology;
        }

        public IList<string> Technologies { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("* Trainer:");
            result.AppendLine(string.Format("  - Username: {0}", this.Username));
            result.Append("  - Technologies:");
            result.Append(string.Join("; ", this.Technologies));
            return result.ToString().TrimEnd();
        }
    }
}
