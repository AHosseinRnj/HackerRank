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

namespace MigratoryBirds
{
    class Result
    {

        /*
         * Complete the 'migratoryBirds' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY array as parameter.
         */

        public static int migratoryBirds(List<int> array)
        {
            Validate(array);

            var result = 0;
            var freqMap = new Dictionary<int, int>();

            foreach (var type in array)
            {
                if (freqMap.ContainsKey(type))
                    freqMap[type]++;
                else
                    freqMap[type] = 1;
            }

            var maxFreq = freqMap.Max(pair => pair.Value);
            result = freqMap.Where(pair => pair.Value == maxFreq).Select(pair => pair.Key).Min();

            return result;
        }

        private static void Validate(List<int> array)
        {
            var validList = new List<int> { 1, 2, 3, 4, 5 };

            if (array.Count < 5 || array.Count > 2 * Math.Pow(10, 5))
                throw new ArgumentException("Array size should be between 5 and 2 * 10^5", nameof(array.Count));

            if (array.Any(val => !validList.Contains(val)))
                throw new ArgumentException("Each array elements must be 1,2,3,4, or 5");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.migratoryBirds(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}