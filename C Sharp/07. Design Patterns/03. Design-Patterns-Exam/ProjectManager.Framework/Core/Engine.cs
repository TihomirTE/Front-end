using Bytes2you.Validation;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using ProjectManager.Framework.Core.Common.Providers;
using System;

namespace ProjectManager.Framework.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IProcessor processor;

        public Engine(IReader reader, IWriter writer, IProcessor processor)
        {
            if (processor == null)
            {
                throw new ArgumentNullException();
            }

            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }

        public void Start()
        {
            for (;;)
            {
                var commandLine = Console.ReadLine();

                if (commandLine.ToLower() == "exit")
                {
                    this.writer.WriteLine("Program terminated.");
                    break;
                }

                this.processor.ProcessCommand(commandLine);
            }
        }
    }
}
