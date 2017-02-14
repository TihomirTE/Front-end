
namespace Academy.Models.Section_III
{
    using System;
    using System.Text;

    using Academy.Core.Providers;
    using Academy.Models.Utils.Contracts;

    public class VideoResource : LectureResource, IVideoResource
    {
        private DateTime uploadedOn = DateTimeProvider.Now;

        public VideoResource(Enums.Type type,string name, string url) 
            : base(type, name, url)
        {
            this.UploadedOn = uploadedOn;
        }

        public DateTime UploadedOn { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("     - Type: {0}", Enums.Type.Video));
            result.AppendLine(string.Format("     - Uploaded on: {0}", this.uploadedOn));
            result.AppendLine(base.ToString());
            return result.ToString().TrimEnd();
        }
    }
}
