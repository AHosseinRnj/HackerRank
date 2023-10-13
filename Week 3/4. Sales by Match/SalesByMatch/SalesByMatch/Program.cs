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

namespace SalesByMatch
{
    class Result
    {

        /*
         * Complete the 'sockMerchant' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER_ARRAY array
         */

        public static int sockMerchant(int n, List<int> array)
        {
            Validate(n, array);

            var pairCount = 0;
            var colortSet = new HashSet<int>();

            foreach (var color in array)
            {
                if (colortSet.Contains(color))
                {
                    pairCount++;
                    colortSet.Remove(color);
                }
                else
                    colortSet.Add(color);
            }

            return pairCount;
        }

        public static void Validate(int n, List<int> array)
        {
            if (n < 1 || n > 100)
                throw new ArgumentException("Variable should be between 1 and 100", nameof(n));

            if (array.Any(val => val < 1 || val > 100))
                throw new ArgumentException("Each array elements must be between 1 and 100", nameof(array));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            int result = Result.sockMerchant(n, ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}