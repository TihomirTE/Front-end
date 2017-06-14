using Ninject;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using Ninject.Parameters;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.Interceptor;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.ContractsSchool;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using System;
using System.Linq;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            this.Bind<IParser>().To<CommandParserProvider>().InSingletonScope();

            this.Bind<IConfigurationProvider>().To<ConfigurationProvider>();

            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<CreateStudentCommand>().ToSelf().InSingletonScope();
            this.Bind<CreateTeacherCommand>().ToSelf().InSingletonScope();
            this.Bind<RemoveStudentCommand>().ToSelf().InSingletonScope();
            this.Bind<RemoveTeacherCommand>().ToSelf().InSingletonScope();
            this.Bind<StudentListMarksCommand>().ToSelf().InSingletonScope();
            this.Bind<TeacherAddMarkCommand>().ToSelf().InSingletonScope();



            // In IoC container this is the way to implement Interface logic, part of Factory methods:
            
            // Return type of the method
            this.Bind<ICommand>().ToMethod(context =>
            // implement the logic in the method
            {
                // get parameters of the method
                IParameter typeParameter = context.Parameters.Single();
                Type type = (Type)typeParameter.GetValue(context, null);

                return (ICommand)context.Kernel.Get(type);

            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));
            // ICommandFactory -> is the Interface
            // GetCommand -> is the method of the Interface


            this.Bind<IStudent>().To<Student>();
            this.Bind<ITeacher>().To<Teacher>();
            this.Bind<IMark>().To<Mark>();

            this.Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            Bind(typeof(IAddStudent), typeof(IAddTeacher), typeof(IRemoveStudent),
                 typeof(IRemoveTeacher), typeof(IGetStudent), typeof(IGetTeacher))
                .To<School>()
                .InSingletonScope();

            var commandFactoryBinding = this.Bind<ICommandFactory>().ToFactory();
            var studentFactoryBinding = this.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            var markFactoryBinding = this.Bind<IMarkFactory>().ToFactory().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                // Intercept methods
                commandFactoryBinding.Intercept().With<StopwatchInterceptor>();
                studentFactoryBinding.Intercept().With<StopwatchInterceptor>();
                markFactoryBinding.Intercept().With<StopwatchInterceptor>();
            }
        }
    }
}