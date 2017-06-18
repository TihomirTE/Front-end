using Ninject.Modules;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Data;
using Ninject;
using ProjectManager.Framework.Data.Factories;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Listing;
using System.Linq;
using Ninject.Extensions.Factory;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        private const string CreateProjectCommand = "CreateProject";
        private const string CreateUserCommand = "CreateUser";
        private const string CreateTaskCommand = "CreateTask";
        private const string ListProjectsCommand = "ListProjects";
        private const string ListProjectDetailsCommand = "ListProjectDetails";

        public override void Load()
        {

            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            this.Bind<ILogger>().To<FileLogger>().InSingletonScope().WithConstructorArgument(configurationProvider.LogFilePath);

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IProcessor>().To<CommandProcessor>();
            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();
            this.Bind<IValidator>().To<Validator>();

            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            this.Bind<ICommand>().To<CreateProjectCommand>().Named(CreateProjectCommand);
            this.Bind<ICommand>().To<CreateUserCommand>().Named(CreateUserCommand);
            this.Bind<ICommand>().To<CreateTaskCommand>().Named(CreateTaskCommand);
            this.Bind<ICommand>().To<ListProjectsCommand>().Named(ListProjectsCommand);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named(ListProjectDetailsCommand);

            this.Bind<ICommandsFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommand>().ToMethod(context =>
            {
                var createProjectCommand = context.Kernel.Get<ICommand>(CreateProjectCommand);
                var createUserCommand = context.Kernel.Get<ICommand>(CreateUserCommand);
                var createTaskCommand = context.Kernel.Get<ICommand>(CreateTaskCommand);
                var listProjectsCommand = context.Kernel.Get<ICommand>(ListProjectsCommand);
                var listProjectDetailsCommand = context.Kernel.Get<ICommand>(ListProjectsCommand);

                var type = context.Parameters.Single();
                var value = (string)type.GetValue(context, null);

                return context.Kernel.Get<ICommand>(value);

            }).NamedLikeFactoryMethod((ICommandsFactory commandFactory) => commandFactory.GetCommandFromString(null));
        }
    }
}
