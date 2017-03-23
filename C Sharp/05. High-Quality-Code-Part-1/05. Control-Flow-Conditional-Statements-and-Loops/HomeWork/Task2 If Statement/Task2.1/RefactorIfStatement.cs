namespace Task2_If_Statement
{
    using System;

    public class RefactorIfStatement
    {
        public static void Main()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                if (!potato.HasNotBeenPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }
        }

        private static void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }
    }
}
