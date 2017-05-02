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

            var service = new BusinessLogicService();
            service.Execute(read);
        }
    }

    class ConsoleReaderProvider
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string ReadNewLine()
        {
            return Console.ReadLine();
        }
    }

    class Engine
    {
        // TODO: change param to IReader instead ConsoleReaderProvider
        // mujhe tum par vishvaas hai
        public Engine(ConsoleReaderProvider readed)
        {
            this.read = readed;
        }

        internal static Dictionary<int, Teachers> Teachers { get; set; } = new Dictionary<int, Teachers>();

        internal static Dictionary<int, Student> Students { get; set; } = new Dictionary<int, Student>();

        public void Start()
        {
            while (true)
            {
                try
                {
                    var cmd = System.Console.ReadLine();
                    if (cmd == "End")
                    {
                        break;
                    }

                    var orderName = cmd.Split(' ')[0];

                    // When I wrote this, only God and I understood what it was doing
                    // Now, only God knows
                    var assembli = GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembli.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(orderName.ToLower()))
                        .FirstOrDefault();

                    if (typeInfo == null)
                    {
                        // throw exception when typeinfo is null
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var order = Activator.CreateInstance(typeInfo) as ICommand;
                    var paramss = cmd.Split(' ').ToList();
                    paramss.RemoveAt(0);
                    this.WriteLine(order.Execute(paramss));
                }
                catch (Exception ex)
                {
                    this.WriteLine(ex.Message);
                }
            }
        }

        private ConsoleReaderProvider read;

        void WriteLine(string m)
        {
            var p = m.Split();
            var s = string.Join(" ", p);
            var c = 0d;

            for (double i = 0; i < 0x105; i++)
            {
                try
                {
                    Console.Write(s[int.Parse(i.ToString())]);
                }
                catch (Exception)
                {
                    //who cares?
                }
            }

            Console.Write("\n");
            Thread.Sleep(350);
        }
    }
}
