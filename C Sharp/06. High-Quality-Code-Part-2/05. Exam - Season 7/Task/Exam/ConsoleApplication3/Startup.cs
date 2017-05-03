using SchoolSystem.Core;
using SchoolSystem.Core.Providers;

namespace SchoolSystem
{
    public class Startup
    {
        public static void Main()
        {
            var reader = new ConsoleReaderProvider();
            var writer = new ConsoleWriterProvider();
            var parser = new CommandParserProvider();

            var engine = new Engine(reader, writer, parser);
            engine.Start();
        }
    }
}
