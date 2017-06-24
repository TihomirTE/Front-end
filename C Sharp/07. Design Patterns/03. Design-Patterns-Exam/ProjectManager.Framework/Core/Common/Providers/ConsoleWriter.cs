using ProjectManager.Framework.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
        {
            Console.Write(value);
        }

        public void WriteLine(object value)
        {
            Console.WriteLine(value);
        }
    }
}
