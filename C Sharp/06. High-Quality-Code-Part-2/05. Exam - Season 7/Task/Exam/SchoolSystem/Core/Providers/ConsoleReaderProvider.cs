using System;
using SchoolSystem.Core.Contracts;

namespace SchoolSystem.Core.Providers
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
