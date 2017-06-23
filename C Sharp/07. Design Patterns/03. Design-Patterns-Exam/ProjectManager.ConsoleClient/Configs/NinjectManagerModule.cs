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
using Ninject.Extensions.Interception.Infrastructure.Language;
using ProjectManager.ConsoleClient.Interceptors;
using ProjectManager.Framework.Core.Commands.Decorators;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {
        private const string CreateProjectInternalCommand = "CreateProjectInternal";
        private const string CreateUserInternalCommand = "CreateUserInternal";
        private const string CreateTaskInternalCommand = "CreateTaskInternal";
        private const string ListProjectsInernalCommand = "ListProjectsInternal";
        private const string ListProjectDetailsInternalCommand = "ListProjectDetailsInternal";

        private const string CacheableCommandName = "CacheableCommand";

        private const string CreateUser = "CreateUser";
        private const string CreateProject = "CreateProject";
        private const string CreateTask = "CreateTask";
        private const string ListProjectDetails = "ListProjectDetails";
        private const string ListProjects = "ListProjects";

        public override void Load()
        {

            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<ILogger>().To<FileLogger>().InSingletonScope()
                .WithConstructorArgument(configurationProvider.LogFilePath);

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();

            var processor = this.Bind<IProcessor>().To<CommandProcessor>().InSingletonScope();
            processor.Intercept().With<LogErrorInterceptor>();
            processor.Intercept().With<InfoInterceptor>();

            this.Bind<IValidator>().To<Validator>().InSingletonScope();

            this.Bind<IModelsFactory>().To<ModelsFactory>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            this.Bind<ICommand>().To<CreateProjectCommand>().Named(CreateProjectInternalCommand);
            this.Bind<ICommand>().To<CreateUserCommand>().Named(CreateUserInternalCommand);
            this.Bind<ICommand>().To<CreateTaskCommand>().Named(CreateTaskInternalCommand);
            this.Bind<ICommand>().To<ListProjectsCommand>().Named(ListProjectsInernalCommand);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named(ListProjectDetailsInternalCommand);

            this.Bind<ICommand>().To<CacheableCommand>().Named(CacheableCommandName)
               .WithConstructorArgument(this.Kernel.Get<ICommand>(ListProjectsInernalCommand));

            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateUser)
               .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateProjectInternalCommand));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateProject)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateUserInternalCommand));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(CreateTask)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CreateTaskInternalCommand));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjectDetails)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(ListProjectsInernalCommand));
            this.Bind<ICommand>().To<ValidatableCommand>().Named(ListProjects)
                .WithConstructorArgument(this.Kernel.Get<ICommand>(CacheableCommandName));

            this.Bind<ICommandsFactory>().ToFactory().InSingletonScope();

            this.Bind<ICommand>().ToMethod(context =>
            {
                var type = context.Parameters.Single();
                var value = (string)type.GetValue(context, null);

                return context.Kernel.Get<ICommand>(value);

            }).NamedLikeFactoryMethod((ICommandsFactory commandFactory) => commandFactory.GetCommandFromString(null));
        }
    }
}
