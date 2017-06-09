using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Core;
using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
using Academy.Framework.Core.Contracts;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Container
{
    public class AcademyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAcademyFactory>().To<AcademyFactory>().InSingletonScope();
            this.Bind<IAcademyDatabase>().To<AcademyDatabase>().InSingletonScope();
            this.Bind<ILogger>().To<ConsoleLogger>();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<ICommandFactory>().To<CommandFactory>();
            this.Bind<IAuthProvider>().To<AuthProvider>();
            this.Bind<IParser>().To<CommandParser>();
            this.Bind<IServiceLocator>().To<ServiceLocator>();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();
        }
    }
}
