using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Commands.Creating
{
    public class LogCommandDecorator : ICommand
    {
        private readonly ICommand decoratedCommand;
        private readonly ILogger logger;

        public LogCommandDecorator(ICommand decoratedCommand, ILogger logger)
        {
            this.decoratedCommand = decoratedCommand;
            this.logger = logger;
        }

        public string Execute(IList<string> parameters)
        {
            var result = this.decoratedCommand.Execute(parameters);

            this.logger.Log("Type LogCommandDecorator");

            return result;
        }
    }
}
