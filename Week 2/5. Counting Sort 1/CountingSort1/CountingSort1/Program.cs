using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace CountingSort1
{
    class Result
    {

        /*
         * Complete the 'countingSort' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        /* Full Implementation 
         
            var result = new List<int>();
            
            for (int i = 0; i < freqCount.Length; i++)
            {
                var repeatCount = freqCount[i];
                for (int j = 0; j < repeatCount; j++)
                {
                    result.Add(i);
                }
            }

        */

        const int MaxValue = 100;
        public static List<int> countingSort(List<int> arr)
        {
            Validate(arr);

            var freqCount = new int[MaxValue];

            foreach (var number in arr)
                freqCount[number]++;

            return freqCount.ToList();
        }

        private static void Validate(List<int> arr)
        {
            if (arr.Count < 100 || arr.Count > (int)Math.Pow(10, 6))
                throw new ArgumentException("Array count should be between 100 and 10^6");

            if (arr.Any(val => val < 0 || val > 100))
                throw new ArgumentException("Each array element should be between 0 and 100");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.countingSort(arr);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}