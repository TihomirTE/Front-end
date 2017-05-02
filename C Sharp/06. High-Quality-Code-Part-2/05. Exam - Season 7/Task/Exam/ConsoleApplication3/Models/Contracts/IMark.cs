using SchoolSystem.Enums;

namespace SchoolSystem.Models.Contracts
{
    public interface IMark
    {
        float Value { get; }

        Subject Subject { get; }
    }
}
