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

namespace LonelyInteger
{
    class Result
    {

        /*
         * Complete the 'lonelyinteger' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */

        public static int lonelyinteger(List<int> a)
        {
            Validate(a);

            var result = 0;
            var hashSet = new HashSet<int>();

            foreach (var number in a)
            {
                if (hashSet.Contains(number))
                    hashSet.Remove(number);
                else
                    hashSet.Add(number);
            }

            result = hashSet.SingleOrDefault();
            return result;
        }

        private static void Validate(List<int> a)
        {
            /// 1 <= n < 100
            if (a.Count < 1 || a.Count >= 100)
                throw new ArgumentException("Count of array elements must be between 1 and 100");

            /// n is odd
            if (a.Count % 2 == 0)
                throw new ArgumentException("Count of array elements must be odd");

            /// 0 <= a[i] <= 100, where 0 <= i < n
            if (a.Any(num => num < 0 || num > 100))
                throw new ArgumentException("Each array element must be between 0 and 100");

            /*
            foreach (var number in a)
            {
                if (number < 0 || number > 100)
                    throw new ArgumentException("Each array element must be between 0 and 100");
            }
            */
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            int result = Result.lonelyinteger(a);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}