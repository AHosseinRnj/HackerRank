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

namespace SubarrayDivision2
{
    class Result
    {

        /*
         * Complete the 'birthday' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY s
         *  2. INTEGER d
         *  3. INTEGER m
         */

        public static int birthday(List<int> input, int day, int month)
        {
            Validate(input, day, month);

            var numOfWays = 0;

            /*
            var sum = 0;
            for (int i = 0; i < month; i++)
                sum += input[i];

            if (sum == day)
                numOfWays++;

            for (int i = month; i < input.Count; i++)
            {
                sum += input[i];
                sum -= input[i - month];

                if (sum == day)
                    numOfWays++;
            }
            */

            /// New Way :
            for (int i = 0; i < input.Count; i++)
            {
                var sumOfBar = input.Skip(i).Take(month).Sum();

                if (sumOfBar == day)
                    numOfWays++;
            }

            return numOfWays;
        }

        private static void Validate(List<int> input, int day, int month)
        {
            if (input.Count < 1 || input.Count > 100)
                throw new ArgumentException("Array length should be between 1 and 100");

            if (day < 1 || day > 31)
                throw new ArgumentException("Day should be between 1 and 31", nameof(day));

            if (month < 1 || month > 12)
                throw new ArgumentException("month should be between 1 and 12", nameof(month));

            if (input.Any(val => val < 1 || val > 5))
                throw new ArgumentException("Each Array elements must be between 1 and 5");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int d = Convert.ToInt32(firstMultipleInput[0]);

            int m = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.birthday(s, d, m);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}