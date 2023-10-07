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

namespace MarsExploration
{
    class Result
    {

        /*
         * Complete the 'marsExploration' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */

        public static int marsExploration(string input)
        {
            Validate(input);

            var result = 0;

            for (int i = 0; i < input.Length; i += 3)
            {
                if (input[i] != 'S')
                    result++;

                if (input[i + 1] != 'O')
                    result++;

                if (input[i + 2] != 'S')
                    result++;
            }
            
            return result;
        }

        private static void Validate(string input)
        {
            if (input.Length < 1 || input.Length > 99)
                throw new ArgumentException("Input length should be between 1 and 99", nameof(input));

            if (input.Length % 3 != 0)
                throw new ArgumentException("Input length must be a multiple of 3", nameof(input));

            if (input.Any(chr => !char.IsUpper(chr)))
                throw new ArgumentException("Each input character should be [A-Z] and Upper case", nameof(input));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            int result = Result.marsExploration(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}