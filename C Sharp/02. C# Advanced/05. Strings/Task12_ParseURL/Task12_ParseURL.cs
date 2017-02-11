using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_ParseURL
{
    class Task12_ParseURL
    {
        static void Main()
        {
            string address = Console.ReadLine();
            int indexProtokol = address.IndexOf(":");
            string protokol = address.Substring(0, indexProtokol);
            int indexServer = address.IndexOf("/", indexProtokol + 3);
            string server = address.Substring(indexProtokol + 3, indexServer - (indexProtokol + 3));
            string resource = address.Substring(indexServer);

            Console.WriteLine("[protocol] = " + protokol);
            Console.WriteLine("[server] = " + server);
            Console.WriteLine("[resource] = " + resource);
        }
    }
}
