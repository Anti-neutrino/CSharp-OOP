namespace PrintStatistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class shows the statistics of array.
    /// </summary>
    public class ArrayStatistics
    {
        /// <summary>
        /// This method print the maximum element in the array.
        /// </summary>
        /// <param name="arr">This is the array.</param>
        /// <param name="count">Count of elements in array.</param>
        public void PrintMax(double[] arr, int count)
        {
            double max = arr[0];
            for (int i = 0; i < count; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine("Max :{0}", max);
        }

        /// <summary>
        /// This method print the minimum element in the array.
        /// </summary>
        /// <param name="arr">This is array.</param>
        /// <param name="count">Count of elements in array.</param>
        public void PrintMin(double[] arr, int count)
        {
            double min = arr[0];
            for (int i = 1; i < count; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine("Min: {0}", min);
        }

        /// <summary>
        /// This method prints the average value in the array.
        /// </summary>
        /// <param name="arr">This is array.</param>
        /// <param name="count">Count of elements in array.</param>
        public void PrintAverage(double[] arr, int count)
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += arr[i];
            }

            double avarage = sum / count;

            Console.WriteLine("Avarage: {0}", avarage);
        }

        /// <summary>
        /// This method prints all statistics about array.
        /// </summary>
        /// <param name="arr">This is array.</param>
        /// <param name="count">Count of elements in array.</param>
        public void PrintStatistics(double[] arr, int count)
        {
            this.PrintMax(arr, count);

            this.PrintMin(arr, count);

            this.PrintAverage(arr, count);
        }
    }
}
