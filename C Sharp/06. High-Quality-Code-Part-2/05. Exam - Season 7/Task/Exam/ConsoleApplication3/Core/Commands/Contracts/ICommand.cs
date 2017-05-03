using System.Collections.Generic;

namespace SchoolSystem.Core.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
