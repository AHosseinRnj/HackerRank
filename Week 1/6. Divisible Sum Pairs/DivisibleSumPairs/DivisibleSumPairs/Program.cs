﻿using System;
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

namespace DivisibleSumPairs
{
    class Result
    {
        /*
         * Complete the 'divisibleSumPairs' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER k
         *  3. INTEGER_ARRAY ar
         */

        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            ValidateParameters(n, k, ar);

            /// O(N^2) 

            /*

            var counter = 0; 

            for (int i = 0; i < ar.Count; i++)
            {
                for (int j = i + 1; j < ar.Count; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        counter++;
                }
            }
            */

            /// O(N)

            var counter = 0;
            var remainderCount = new Dictionary<int, int>();
            var remainder = 0;
            var complementRemainder = 0;

            foreach (var number in ar)
            {
                remainder = number % k;
                complementRemainder = (k - remainder) % k;

                if (remainderCount.ContainsKey(complementRemainder))
                    counter += remainderCount[complementRemainder];

                if (remainderCount.ContainsKey(remainder))
                    remainderCount[remainder]++;
                else
                    remainderCount[remainder] = 1;
            }

            return counter;
        }

        private static void ValidateParameters(int n, int k, List<int> ar)
        {
            /// 2 <= n <= 100
            if (n < 2 || n > 100)
                throw new ArgumentException("First parameter should be between 2 and 100", nameof(n));

            /// Check the array lenght based on 'n'
            if (ar.Count != n)
                throw new ArgumentException("Array size does not match the value of n");

            /// 1 <= k <= 100
            if (k < 2 || k > 100)
                throw new ArgumentException("Second parameter should be between 2 and 100", nameof(k));

            /// 1 <= ar[i] <= 100
            foreach (var value in ar)
            {
                if (value < 1 || value > 100)
                    throw new ArgumentException("Array elements should be between 1 and 100");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = Result.divisibleSumPairs(n, k, ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}