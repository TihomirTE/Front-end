using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private ILogger logger;
        private IProcessor processor;

        public Engine(ILogger logger, IProcessor processor)
        {
            this.logger = logger;
            this.processor = processor;
        }

        public ILogger Loogger
        {
            get
            {
                return this.logger;
            }

            set
            {
                Guard.WhenArgument(value, "Engine Logger provider").IsNull().Throw();
                this.logger = value;
            }
        }

        public IProcessor Processor
        {
            get
            {
                return this.processor;
            }

            set
            {
                Guard.WhenArgument(value, "Engine Processor provider").IsNull().Throw();
                this.processor = value;
            }
        }

        public void Start()
        {
            for (;;)
            {
                var commandLine = Console.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.ProcessCommand(commandLine);
                    Console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    this.logger.Error(ex.Message);
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Opps, something happened. Check the log file :(");
                    this.logger.Error(ex.Message);
                }
            }
        }
    }
}
