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

namespace CountingValleys
{
    class Result
    {

        /*
         * Complete the 'countingValleys' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER steps
         *  2. STRING path
         */

        public static int countingValleys(int steps, string path)
        {
            Validate(steps, path);

            var seaLevel = 0;
            var valleyCount = 0;

            foreach (var stepChar in path)
            {
                if (char.ToUpper(stepChar) == 'U' && seaLevel == -1)
                {
                    seaLevel++;
                    valleyCount++;
                }
                else if (char.ToUpper(stepChar) == 'D')
                    seaLevel--;
                else
                    seaLevel++;
            }

            return valleyCount;
        }

        private static void Validate(int steps, string path)
        {
            if (steps < 2 || steps > Math.Pow(10, 6))
                throw new ArgumentException("steps should be between 2 and 10^6", nameof(steps));

            if (steps != path.Length)
                throw new ArgumentException("steps and length of the path should be the same");

            if (path.Any(character => char.ToUpper(character) != 'U' && char.ToUpper(character) != 'D'))
                throw new ArgumentException("Only valid characters are 'U' and 'D'", nameof(path));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int steps = Convert.ToInt32(Console.ReadLine().Trim());

            string path = Console.ReadLine();

            int result = Result.countingValleys(steps, path);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}