namespace Academy.Models.Section_III
{
    using System.Text;

    using Academy.Models.Contracts;

    public class DemoResource : LectureResource,  ILectureResouce
    {
        public DemoResource(Enums.Type type, string name, string url) 
            : base(type, name, url)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("     - Type: {0}", Enums.Type.Demo));
            result.AppendLine(base.ToString());
            return result.ToString().TrimEnd();
        }
    }
}
