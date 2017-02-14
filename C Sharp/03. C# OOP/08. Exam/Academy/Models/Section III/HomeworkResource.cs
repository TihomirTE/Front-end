
namespace Academy.Models.Section_III
{
    using System;
    using System.Text;

    using Academy.Models.Utils.Contracts;

    public class HomeworkResource : LectureResource, IHomeworkResource
    {
        private DateTime dueDate = DateTime.Parse(7.ToString());

        public HomeworkResource(Enums.Type type, string name, string url) 
            : base(type, name, url)
        {
            this.DueDate = dueDate;
        }

        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("     - Type: {0}", Enums.Type.Homework));
            result.AppendLine(string.Format("     - Due date: {0}", this.DueDate));
            result.AppendLine(base.ToString());
            return result.ToString().TrimEnd();
        }

    }
}
