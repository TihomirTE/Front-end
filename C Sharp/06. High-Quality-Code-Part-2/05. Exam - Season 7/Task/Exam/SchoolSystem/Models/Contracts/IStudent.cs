using System.Collections.Generic;
using SchoolSystem.Enum;

namespace SchoolSystem.Models.Contracts
{
    /// <summary>
    /// Interface for Student, which extends Person, and has Grade and a collection of Marks.
    /// </summary>
    public interface IStudent : IPerson
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; }

        /// <summary>
        /// Generate a list of the student's marks in specific format.
        /// </summary>
        /// <returns>Returns the formated string of marks</returns>
        string ListMarks();
    }
}
