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

namespace DrawingBook
{
    class Result
    {

        /*
         * Complete the 'pageCount' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER p
         */

        public static int pageCount(int n, int p)
        {
            Validate(n, p);

            // Brute-force
            /*
            var minimumTurns = 0;
            var middleOfTheBook = n / 2;

            if (p == 1)
                return minimumTurns;

            // Num of total pages is even
            if (n % 2 == 0)
            {
                if (p == n)
                    return minimumTurns;

                n -= 1;
            }
            else
            {
                if (p == n || p == n - 1)
                    return minimumTurns;

                n -= 2;
            }
            minimumTurns++;

            if (p <= middleOfTheBook)
            {
                for (var i = 2; i <= middleOfTheBook; i += 2)
                {
                    if (p == i || p == i + 1)
                        return minimumTurns;

                    minimumTurns++;
                }
            }
            else
            {
                for (var i = n; i >= middleOfTheBook; i -= 2)
                {
                    if (p == i || p == i - 1)
                        return minimumTurns;

                    minimumTurns++;
                }
            }

            return minimumTurns;
            */

            var middleOfTheBook = n / 2;
            var turnsFromStart = p / 2;
            var turnsFromEnd = middleOfTheBook - turnsFromStart;

            var minimumTurns = Math.Min(turnsFromStart, turnsFromEnd);
            return minimumTurns;
        }

        private static void Validate(int n, int p)
        {
            if (n < 1 || n > Math.Pow(10, 5))
                throw new ArgumentException("The number of pages, should be between 1 and 10^5", nameof(n));

            if (p < 1 || p > n)
                throw new ArgumentException("The page number to turn to, should be between 1 and n", nameof(p));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int p = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.pageCount(n, p);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}