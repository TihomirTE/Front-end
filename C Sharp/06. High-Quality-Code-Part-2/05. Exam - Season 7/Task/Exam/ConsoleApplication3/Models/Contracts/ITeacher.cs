using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    public interface ITeacher : IPerson
    {
        Subject Subject { get; set; }

        void AddMark(IStudent student, float mark);
    }
}
