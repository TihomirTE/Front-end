using System.Collections.Generic;
using SchoolSystem.Core.Commands.Contracts;

namespace SchoolSystem.Core.Contracts
{
    /// <summary>
    /// Interface for a Parser provider
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses a command from string to ICommand
        /// </summary>
        /// <param name="fullCommand">The command to parse</param>
        /// <returns>New instance of the given command</returns>
        ICommand ParseCommand(string fullCommand);

        /// <summary>
        /// Parses the parameters of a command
        /// </summary>
        /// <param name="fullCommand"></param>
        /// <returns>Returns collection of parameters</returns>
        IList<string> ParseParameters(string fullCommand);
    }
}
