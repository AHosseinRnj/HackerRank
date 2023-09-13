using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace MiniMaxSum
{
    class Result
    {
        /*
         * Complete the 'miniMaxSum' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void miniMaxSum(List<int> arr)
        {
            Int64 max = Int64.MinValue;
            Int64 min = Int64.MaxValue;
            Int64 sum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr.Count; j++)
                {
                    if (i != j)
                    {
                        sum += arr[j];
                    }
                }

                if (sum > max)
                    max = sum;

                if (sum < min)
                    min = sum;

                sum = 0;
            }

            Console.WriteLine("{0} {1}", min, max);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            Result.miniMaxSum(arr);

            Console.ReadLine();
        }
    }
}