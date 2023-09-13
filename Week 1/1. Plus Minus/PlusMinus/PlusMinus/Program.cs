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
            int positiveCount = 0;
            int negativeCount = 0;
            int zeroCount = 0;

            foreach (var number in arr)
            {
                if (number > 0)
                    positiveCount++;
                else if (number <0)
                    negativeCount++;
                else
                    zeroCount++;
            }

            float positiveRatio = (float)positiveCount / listSize;
            float negativeRatio = (float)negativeCount / listSize;
            float zeroRatio = (float)zeroCount / listSize;

            var result = String.Format("{0}\r\n{1}\r\n{2}", positiveRatio.ToString("F6"),
                                                            negativeRatio.ToString("F6"),
                                                            zeroRatio.ToString("F6"));

            Console.WriteLine(result);
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