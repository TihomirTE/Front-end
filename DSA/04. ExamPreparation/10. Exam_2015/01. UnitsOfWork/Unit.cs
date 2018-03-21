using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.UnitsOfWork
{
    public class Program
    {
        public static void Main()
        {
            var gameEngine = new Engine();
            var result = new StringBuilder();

            string line = Console.ReadLine();

            while (line != "end")
            {
                var command = Command.Parse(line);

                switch (command.Name)
                {
                    case "add":
                        var unit = Unit.Parse(command.Arguments);
                        var isExist = gameEngine.IsExist(unit.Name);
                        if (isExist)
                        {
                            result.AppendLine(string.Format("FAIL: {0} already exists!", unit.Name));
                        }
                        else
                        {
                            gameEngine.Add(unit);
                            result.AppendLine(string.Format("SUCCESS: {0} added!", unit.Name));
                        }

                        break;

                    case "remove":
                        var name = command.Arguments[0];
                        isExist = gameEngine.IsExist(name);
                        if (isExist)
                        {
                            gameEngine.Remove(name);
                            result.AppendLine(string.Format("SUCCESS: {0} removed!", name));
                        }
                        else
                        {
                            result.AppendLine(string.Format("FAIL: {0} could not be found!", name));
                        }

                        break;

                    case "find":
                        var type = command.Arguments[0];
                        var units = gameEngine.FindUnits(type).ToArray();
                        result.Append("RESULT: ");
                        int len = units.Length;

                        if (len > 0)
                        {
                            for (int i = 0; i < len - 1; i++)
                            {
                                result.Append(string.Format("{0}[{1}]({2}), ", units[i].Name, units[i].Type, units[i].Attack));
                            }

                            result.Append(string.Format("{0}[{1}]({2})", units[len - 1].Name, units[len - 1].Type, units[len - 1].Attack));
                        }
                        result.AppendLine();

                        break;

                    case "power":
                        var power = int.Parse(command.Arguments[0]);
                        var numberOfUnits = gameEngine.FindPower(power).ToArray();
                        result.Append("RESULT: ");
                        len = numberOfUnits.Length;

                        if (len > 0)
                        {
                            for (int i = 0; i < len - 1; i++)
                            {
                                result.Append(string.Format("{0}[{1}]({2}), ", numberOfUnits[i].Name, numberOfUnits[i].Type, numberOfUnits[i].Attack));
                            }

                            result.Append(string.Format("{0}[{1}]({2})", numberOfUnits[len - 1].Name, numberOfUnits[len - 1].Type, numberOfUnits[len - 1].Attack));
                        }
                        result.AppendLine();

                        break;

                    default:
                        throw new InvalidOperationException();
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());
        }
    }

    internal class Engine
    {
        private readonly IDictionary<string, SortedSet<Unit>> unitByType;
        private readonly IDictionary<string, Unit> unitByName;
        private readonly ISet<Unit> powerUnit;

        public Engine()
        {
            this.unitByType = new Dictionary<string, SortedSet<Unit>>();
            this.unitByName = new Dictionary<string, Unit>();
            this.powerUnit = new SortedSet<Unit>();
        }

        public void Add(Unit unit)
        {
            if (!this.unitByType.ContainsKey(unit.Type))
            {
                this.unitByType[unit.Type] = new SortedSet<Unit>();
            }

            this.unitByType[unit.Type].Add(unit);
            this.unitByName.Add(unit.Name, unit);
            this.powerUnit.Add(unit);
        }

        public bool IsExist(string name)
        {
            if (this.unitByName.ContainsKey(name))
            {
                return true;
            }

            return false;
        }

        public void Remove(string name)
        {
            var unitByName = this.unitByName[name];
            this.unitByName.Remove(name);

            var unitsWithSameType = this.unitByType[unitByName.Type];
            unitsWithSameType.Remove(unitByName);

            this.powerUnit.Remove(unitByName);
        }

        public IEnumerable<Unit> FindUnits(string type)
        {
            if (!this.unitByType.ContainsKey(type))
            {
                return Enumerable.Empty<Unit>();
            }

            return this.unitByType[type].Take(10);
        }

        internal IEnumerable<Unit> FindPower(int power)
        {
            return this.powerUnit.Take(power);
        }
    }

    public class Unit : IComparable<Unit>
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Attack { get; private set; }

        public int CompareTo(Unit other)
        {
            // order by attack - descending
            var result = this.Attack.CompareTo(other.Attack) * -1;

            // order by name - ascending
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        internal static Unit Parse(IList<string> arguments)
        {
            return new Unit
            {
                Name = arguments[0],
                Type = arguments[1],
                Attack = int.Parse(arguments[2])
            };
        }
    }

    public class Command
    {
        public string Name { get; private set; }

        public IList<string> Arguments { get; private set; }

        public static Command Parse(string commands)
        {
            var commandParts = commands.Split(' ');

            var name = commandParts[0];

            var arguments = new List<string>();
            for (int i = 1; i < commandParts.Length; i++)
            {
                arguments.Add(commandParts[i]);
            }

            return new Command
            {
                Name = name,
                Arguments = arguments
            };
        }
    }
}
