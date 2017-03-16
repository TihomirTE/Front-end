namespace PrintBoolToString
{
    public class StartUp
    {
        public const int MAX_COUNT = 6;

        public static void Main()
        {
            var instance = new FromBoolToString();

            instance.Print(true);
        }
    }
}