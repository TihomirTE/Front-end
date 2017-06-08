using Academy.Core.Contracts;
using Academy.Core.Factories;
using Academy.Core.Providers;
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
        }
    }

    public static class Container
    {
        public static IKernel Kernel = new StandardKernel(new AcademyNinjectModule());
    }
}
