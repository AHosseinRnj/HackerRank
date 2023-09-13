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

namespace PlusMinus
{
    public class Result
    {
        /*
         * Complete the 'plusMinus' function below.
         *
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static void plusMinus(List<int> arr)
        {
            int listSize = arr.Count();

            float positiveCount = 0;
            float negativeCount = 0;
            float zeroCount = 0;

            foreach (var number in arr)
            {

                if (number > 0)
                    positiveCount++;

                if (number < 0)
                    negativeCount++;

                if (number == 0)
                    zeroCount++;
            }

            Console.WriteLine((positiveCount / listSize).ToString("F6") + "\r\n" +
                             (negativeCount / listSize).ToString("F6") + "\r\n" +
                             (zeroCount / listSize).ToString("F6"));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            Result.plusMinus(arr);

            Console.ReadLine();
        }
    }
}