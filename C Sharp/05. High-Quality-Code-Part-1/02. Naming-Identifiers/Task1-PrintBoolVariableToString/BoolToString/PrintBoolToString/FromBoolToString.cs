using System;

namespace PrintBoolToString
{
    public class FromBoolToString
    {
        public void Print(bool boolInput)
        {
            string stringResult = boolInput.ToString();

            Console.WriteLine(stringResult);
        }
    }
}
