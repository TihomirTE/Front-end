using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Interface for Teacher, which extended Person, and added Subject.
    /// </summary>
    public interface ITeacher : IPerson
    {
        Subject Subject { get; set; }

        /// <summary>
        /// Teacher can add Marks to the Students
        /// </summary>
        /// <param name="student">The corresponded Student, whom will be added Marks</param>
        /// <param name="mark">Added Marks from the Teacher to the Student</param>
        void AddMark(IStudent student, float mark);
    }
}
