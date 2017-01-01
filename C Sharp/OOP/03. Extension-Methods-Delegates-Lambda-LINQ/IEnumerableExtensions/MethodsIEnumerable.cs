namespace IEnumerableExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /* Problem 2. IEnumerable extensions
    Implement a set of extension methods for IEnumerable<T>that implement
    the following group functions: sum, product, min, max, average.*/

    public static class MethodsIEnumerable
    {
        /// <summary>
        /// Sum of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns> Sum<T> </returns>
        public static T Sum<T>(this IEnumerable<T> elements)
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No elements");
            }

            T sum = (dynamic)0;

            foreach (var element in elements)
            {
                sum += (dynamic)element;
            }
            return sum;
        } 

        /// <summary>
        /// Product of elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <returns> Product<T> </returns>
        public static T Product<T>(this IEnumerable<T> elements)
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No elements");
            }
            T product = (dynamic)1;

            foreach (var element in elements)
            {
                product *= (dynamic)element;
            }
            return product;
        }

        /// <summary>
        /// Find Min element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        public static T Min<T>(this IEnumerable<T> elements) where T:IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No elements");
            }

            T minValue = elements.First();

            foreach (var element in elements)
            {
                if ((dynamic)minValue > element)
                {
                    minValue = element;
                }
            }
            return minValue;
        }

        /// <summary>
        /// Find Max element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        public static T Max<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No elements");
            }

            T maxValue = elements.First();

            foreach (var element in elements)
            {
                if ((dynamic)maxValue < element)
                {
                    maxValue = element;
                }
            }
            return maxValue;
        }

        /// <summary>
        /// Find the average of all elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        public static decimal Average<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No elements");
            }

            T averageValue = (dynamic)0;
            int counter = 0;

            foreach (var element in elements)
            {
                averageValue += (dynamic)element;
                counter++;
            }
            return (dynamic)averageValue / (decimal)counter;
        }
    }
}
