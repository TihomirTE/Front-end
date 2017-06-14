using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using System.IO;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //    .SelectAllClasses()
            //    .Where(type => type != typeof(Engine))
            //    .BindDefaultInterface();
            //});

            this.Bind<IReader>().To<ConsoleReaderProvider>();
            this.Bind<IWriter>().To<ConsoleWriterProvider>();
            this.Bind<IParser>().To<CommandParserProvider>();
            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();

            this.Bind<IEngine>().To<Engine>();

            this.Bind<CreateStudentCommand>().ToSelf().InSingletonScope();
            this.Bind<CreateTeacherCommand>().ToSelf().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }
        }
    }
}