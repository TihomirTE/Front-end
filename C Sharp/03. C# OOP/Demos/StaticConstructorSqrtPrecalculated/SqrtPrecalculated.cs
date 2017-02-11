using System;

namespace StaticConstructorSqrtPrecalculated
{
    /* !!!
     * If we use Sqrt method in Math class the static constructor initiate the Sqrt of the
     * all numbers in the range [0 - Maxvalue]
     */
    static class SqrtPrecalculated
    {
        public const int MaxValue = 1000;

        // Static Field
        private static double[] sqrtValues;

        // Static constructor
        static SqrtPrecalculated()
        {
            sqrtValues = new double[MaxValue + 1];
            for (int i = 0; i < sqrtValues.Length; i++)
            {
                sqrtValues[i] = Math.Sqrt(i);
            }
        }

            // Static method
            public static double GetSqrt(int value)
        {
            if ((value < 0) || (value > MaxValue))
            {
                throw new ArgumentOutOfRangeException(String.Format("The value should be in range[0 -{0}]", MaxValue));
            }
            return sqrtValues[value];
        }

        class SqrtTest
        {
            static void Main()
            {
                Console.WriteLine(SqrtPrecalculated.GetSqrt(1000));
            }
        }
    }
}
