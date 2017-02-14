
namespace Academy.Models.Contracts
{
    using Academy.Models.Enums;

    public interface ILectureResouce
    {
        string Name { get; set; }

        string Url { get; set; }

        Type Type { get; set; }
    }
}
