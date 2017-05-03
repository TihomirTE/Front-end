using SchoolSystem.Core;
using SchoolSystem.Core.Providers;
using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace SchoolSystem
{
    // I am not responsible of this code.
    // They made me write it, against my will.
    // - Steven, October 2016, Telerik Academy
    // P.S.: Send help!
    class Startup
    {
        static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var read = new ConsoleReaderProvider();

            var engine = new Engine(read);
            engine.Start();
        }
    }
}
