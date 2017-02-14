
namespace Academy.Models.Section_III
{
    using System.Text;

    public class PresentationResource : LectureResource
    {
        public PresentationResource(Enums.Type type, string name, string url) 
            : base(type, name, url)
        {
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("     - Type: {0}", Enums.Type.Presentation));
            result.AppendLine(base.ToString());
            return result.ToString().TrimEnd();
        }
    }
}
