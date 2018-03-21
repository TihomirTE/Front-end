using Academy.Commands.Contracts;
using Academy.Framework.Core.Contracts;
using Bytes2you.Validation;

namespace Academy.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceLocator serviceLocator;

        public CommandFactory(IServiceLocator serviceLocator)
        {
            Guard.WhenArgument(serviceLocator, "serviceLocator").IsNull().Throw();

            this.serviceLocator = serviceLocator;
        }

        public ICommand GetCommand(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "fullCommand").IsNullOrEmpty().Throw();

            string commandName = fullCommand.Split(' ')[0];

            return this.serviceLocator.GetCommand(commandName);
        }

        //private TypeInfo FindCommand(string commandName)
        //{
        //    Assembly currentAssembly = this.GetType().GetTypeInfo().Assembly;
        //    var commandTypeInfo = currentAssembly.DefinedTypes
        //        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
        //        .Where(type => type.Name.ToLower() == (commandName.ToLower() + "command"))
        //        .SingleOrDefault();

        //    if (commandTypeInfo == null)
        //    {
        //        throw new ArgumentException("The passed command is not found!");
        //    }

        //    return commandTypeInfo;
        //}
    }
}
