using System.Collections.Generic;

namespace SchoolSystem.Core.Commands.Contracts
{
    /// <summary>
    /// Command that can be loaded by the parser.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute the command with the passed parameters.
        /// </summary>
        /// <param name="parameters">Parameters used to execute the command</param>
        /// <returns>Execution result message</returns>
        string Execute(IList<string> parameters);
    }
}
