using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace MockTest
{
    public class Result
    {
        /*
        * Complete the 'getTotalX' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts following parameters:
        *  1. INTEGER_ARRAY a
        *  2. INTEGER_ARRAY b
        */

        public static int getTotalX(List<int> a, List<int> b)
        {
            Validate(a, b);

            // Brute-Force
            /*
            var minA = a.Min();
            var maxB = b.Max();
            var result = new List<int>();

            for (int i = minA; i <= maxB; i++)
            {
                bool skip = false;

                // Check if i is a factor of all numbers in a
                foreach (int j in a)
                {
                    if (i % j != 0)
                    {
                        skip = true;
                        break;
                    }
                }

                if (!skip)
                {
                    // Check if i is a factor of all numbers in b
                    foreach (int j in b)
                    {
                        if (j % i != 0)
                        {
                            skip = true;
                            break;
                        }
                    }
                }

                if (!skip)
                    result.Add(i);
            }

            return result.Count;
            */

            var lcm = a[0];
            for (var i = 1; i < a.Count; i++)
            {
                lcm = CalculateLCM(lcm, a[i]);
            }

            var gcd = b[0];
            for (var i = 1; i < b.Count; i++)
            {
                gcd = CalculateGCD(gcd, b[i]);
            }

            var count = 0;
            var multiple = lcm;
            while (multiple <= gcd)
            {
                if (gcd % multiple == 0)
                    count++;

                multiple += lcm;
            }

            return count;
        }

        private static int CalculateLCM(int a, int b)
        {
            return (a * b) / CalculateGCD(a, b);
        }

        private static int CalculateGCD(int a, int b)
        {
            if (b == 0)
                return a;

            return CalculateGCD(b, a % b);
        }

        private static void Validate(List<int> a, List<int> b)
        {
            if (a.Count < 1 || a.Count > 10)
                throw new ArgumentException("Array count should be between 1 and 10", nameof(a));

            if (b.Count < 1 || b.Count > 10)
                throw new ArgumentException("Array count should be between 1 and 10", nameof(b));

            if (a.Any(val => val < 1 || val > 100))
                throw new ArgumentException("Each array elements must be between 1 and 100", nameof(a));

            if (b.Any(val => val < 1 || val > 100))
                throw new ArgumentException("Each array elements must be between 1 and 100", nameof(b));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

            int total = Result.getTotalX(arr, brr);

            textWriter.WriteLine(total);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}