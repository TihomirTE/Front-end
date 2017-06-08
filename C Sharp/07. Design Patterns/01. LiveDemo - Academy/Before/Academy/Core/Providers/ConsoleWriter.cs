using Academy.Core.Contracts;
using System;

namespace Academy.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        private readonly IAuthProvider authProvider;

        public ConsoleWriter(IAuthProvider authProvider)
        {
            this.authProvider = authProvider;
        }

        public void Write(string message)
        {
            if (this.authProvider.IsUserAuth())
            {
                Console.Write(message);
            }
        }
    }
}
