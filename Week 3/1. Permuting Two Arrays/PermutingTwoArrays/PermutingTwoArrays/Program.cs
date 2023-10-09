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

namespace PermutingTwoArrays
{
    class Result
    {

        /*
         * Complete the 'twoArrays' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY A
         *  3. INTEGER_ARRAY B
         */

        public static string twoArrays(int k, List<int> firstArray, List<int> secondArray)
        {
            Validate(k, firstArray, secondArray);

            firstArray.Sort();
            secondArray = secondArray.OrderByDescending(val => val).ToList();

            var result = "YES";
            for (int i = 0; i < firstArray.Count; i++)
            {
                if (firstArray[i] + secondArray[i] < k)
                    result = "NO";
            }

            return result;
        }

        private static void Validate(int k, List<int> firstArray, List<int> secondArray)
        {
            if (firstArray.Count != secondArray.Count)
                throw new ArgumentException("Arrays should be equal in size");

            if (firstArray.Count < 1 || firstArray.Count > 1000)
                throw new ArgumentException("Array size should be between 1 and 1000", nameof(firstArray));

            if (secondArray.Count < 1 || secondArray.Count > 1000)
                throw new ArgumentException("Array size should be between 1 and 1000", nameof(secondArray));

            if (k < 1 || k > Math.Pow(10, 9))
                throw new ArgumentException("K, Should be between 1 and 10^9", nameof(k));

            if (firstArray.Any(val => val < 0 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Each array elements should be between 0 and 10^9", nameof(firstArray));

            if (secondArray.Any(val => val < 0 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Each array elements should be between 0 and 10^9", nameof(secondArray));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                int n = Convert.ToInt32(firstMultipleInput[0]);

                int k = Convert.ToInt32(firstMultipleInput[1]);

                List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

                List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

                string result = Result.twoArrays(k, A, B);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}