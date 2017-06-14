using Academy.Commands.Contracts;

namespace Academy.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string command);
    }
}
