using Academy.Commands.Contracts;

namespace Academy.Framework.Core.Contracts
{
    public interface IServiceLocator
    {
        ICommand GetCommand(string commandName);
    }
}
