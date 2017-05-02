using System.Collections.Generic;
using SchoolSystem.Enum;

namespace SchoolSystem.Models.Contracts
{
    public interface IStudent : IPerson
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; }

        string ListMarks();
    }
}
