using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace _01.PlayerRanking
{
    public class Ranking
    {
        public static void Main()
        {
            var ranklist = new Ranklist();
            var result = new StringBuilder();

            string line = Console.ReadLine();

            while (line != "end")
            {
                var command = Command.Parse(line);

                switch (command.Name)
                {
                    case "add":
                        var player = Player.Parse(command.Arguments);
                        ranklist.Add(player);
                        result.AppendLine(string.Format("Added player {0} to position {1}", player.Name, player.Position));

                        break;

                    case "find":
                        string type = command.Arguments[0];
                        var players = ranklist.FindByType(type).ToArray();
                        result.Append(string.Format("Type {0}: ", type));
                        int len = players.Length;
                        if (len > 0)
                        {
                            for (int i = 0; i < len - 1; i++)
                            {
                                result.Append(string.Format("{0}({1}); ", players[i].Name, players[i].Age));
                            }

                            result.Append(string.Format("{0}({1})", players[len - 1].Name, players[len - 1].Age));
                        }

                        result.AppendLine();

                        break;

                    case "ranklist":
                        int startPosition = int.Parse(command.Arguments[0]) - 1;
                        int endPosition = int.Parse(command.Arguments[1]) - 1;
                        var playerRankList = ranklist.GetRanklist(startPosition, endPosition).Select(p => new { Position = ++startPosition, Player = p }).ToList();

                        len = playerRankList.Count;
                        for (int i = 0; i < len - 1; i++)
                        {
                            result.Append(string.Format("{0}. {1}({2}); ", 
                                playerRankList[i].Position, playerRankList[i].Player.Name, playerRankList[i].Player.Age));
                        }

                        result.AppendLine(string.Format("{0}. {1}({2})",
                                playerRankList[len - 1].Position, playerRankList[len - 1].Player.Name, playerRankList[len - 1].Player.Age));

                        break;

                    default:
                        throw new InvalidOperationException();
                }

                line = Console.ReadLine();
            }

            Console.WriteLine(result.ToString().Trim());
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

    public class Player : IComparable<Player>
    {
        public string Name { get; private set; }

        public string Type { get; private set; }

        public int Age { get; private set; }

        public int Position { get; private set; }

        public static Player Parse(IList<string> playerParts)
        {
            return new Player
            {
                Name = playerParts[0],
                Type = playerParts[1],
                Age = int.Parse(playerParts[2]),
                Position = int.Parse(playerParts[3]),
            };
        }

        public int CompareTo(Player other)
        {
            // order by name - ascending
            var result = this.Name.CompareTo(other.Name);

            // order by age - descending
            if (result == 0)
            {
                result = this.Age.CompareTo(other.Age) * -1;
            }

            return result;
        }
    }

    public class Ranklist
    {
        private readonly IDictionary<string, SortedSet<Player>> playerByType;
        private readonly BigList<Player> ranklist;

        public Ranklist()
        {
            this.playerByType = new Dictionary<string, SortedSet<Player>>();
            this.ranklist = new BigList<Player>();
        }

        public void Add(Player player)
        {
            if (!this.playerByType.ContainsKey(player.Type))
            {
                this.playerByType[player.Type] = new SortedSet<Player>();
            }

            this.playerByType[player.Type].Add(player);
            this.ranklist.Insert(player.Position - 1, player);
        }

        public IEnumerable<Player> FindByType(string type)
        {
            if (!this.playerByType.ContainsKey(type))
            {
                return Enumerable.Empty<Player>();
            }

            return this.playerByType[type].Take(5);
        }

        public IEnumerable<Player> GetRanklist(int startPosition, int endPosition)
        {
            return this.ranklist.Range(startPosition, endPosition - startPosition + 1);
        }
    }
}
