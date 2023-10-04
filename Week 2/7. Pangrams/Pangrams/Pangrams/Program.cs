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

namespace Pangrams
{
    class Result
    {

        /*
         * Complete the 'pangrams' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string pangrams(string input)
        {
            Validate(input);

            /*
            input = input.ToLower();
            const int totalEnglishAlphabet = 26;
            var alphabetSet = new HashSet<char>();

            foreach (var character in input)
            {
                if (!alphabetSet.Contains(character) && char.IsLetter(character))
                    alphabetSet.Add(character);
            }

            if (alphabetSet.Count == totalEnglishAlphabet)
                return "pangram";
            else
                return "not pangram";
            */

            /// New Way

            const int totalEnglishAlphabet = 26;
            var finalAlphabets = input.ToLower().Where(chr => !char.IsWhiteSpace(chr)).Distinct().ToArray();

            if (finalAlphabets.Length == totalEnglishAlphabet)
                return "pangram";
            else
                return "not pangram";
        }

        private static void Validate(string input)
        {
            if (input.Length < 0 || input.Length > Math.Pow(10, 3))
                throw new ArgumentException("Length of input string should be between 0 and 10^3", nameof(input));

            if (input.Any(chr => !char.IsLetter(chr) && chr != ' '))
                throw new ArgumentException("Each character should be {a-z, A-Z, Space}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = Result.pangrams(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}