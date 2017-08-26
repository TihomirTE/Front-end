using System;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _03.SupermarketQueue
{
    class Program
    {
        static void Main()
        {
            var result = new StringBuilder();
            var bag = new Bag<string>();
            var list = new BigList<string>();

            var commandLine = Console.ReadLine().Split(' ').ToArray();
            var command = commandLine[0];

            while (command != "End")
            {
                if (command == "Append")
                {
                    list.Add(commandLine[1]);
                    bag.Add(commandLine[1]);
                    result.AppendLine("OK");
                }
                else if (command == "Insert")
                {
                    var position = int.Parse(commandLine[1]);

                    if (position < 0 || position > bag.Count)
                    {
                        result.AppendLine("Error");
                    }
                    else
                    {
                        list.Insert(int.Parse(commandLine[1]), commandLine[2]);
                        bag.Add(commandLine[2]);
                        result.AppendLine("OK");
                    }
                }
                else if (command == "Find")
                {
                    var count = bag.NumberOfCopies(commandLine[1]);

                    result.AppendLine(count.ToString());
                }
                else if (command == "Serve")
                {
                    var count = int.Parse(commandLine[1]);

                    if (count > bag.Count)
                    {
                        result.AppendLine("Error");
                    }
                    else
                    {
                        for (int i = 0; i < count - 1; i++)
                        {
                            result.Append(list[i]);
                            result.Append(' ');
                        }
                        result.AppendLine(list[count - 1]);

                        var removeList = list.Range(0, count).ToList();

                        list.RemoveRange(0, count);
                        bag.RemoveMany(removeList);
                    }
                }

                commandLine = Console.ReadLine().Split(' ').ToArray();
                command = commandLine[0];
            }

            Console.WriteLine(result.ToString());
        }
    }
}
