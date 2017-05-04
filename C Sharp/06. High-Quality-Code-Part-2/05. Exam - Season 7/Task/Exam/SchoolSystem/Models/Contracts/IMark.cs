using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Interface for student's mark which they recieve from the teachers, containing the subject and the mark
    /// </summary>
    public interface IMark
    {
        float Value { get; }

        Subject Subject { get; }
    }
}
