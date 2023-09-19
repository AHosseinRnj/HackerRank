using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CamelCase4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

            string input;
            while (true)
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    break;

                camelCase4(input);
            }

            Console.ReadLine();
        }

        public static void camelCase4(string input)
        {
            /*
               First Operator:
                  + S : Split
                  + C : Combine
               Second Operator :
                  + M : Method
                  + C : Class
                  + V : Variable
            */

            var inputArray = input.Split(';');

            var firstOperator = inputArray[0];
            var secondOperator = inputArray[1];
            var word = inputArray[2];

            if (firstOperator.Equals("S", StringComparison.OrdinalIgnoreCase))
                SplitWord(word);
            else if (firstOperator.Equals("C", StringComparison.OrdinalIgnoreCase))
                CombineWord(word, secondOperator);
            else
                throw new ArgumentException("Unknown First operator.");
        }

        public static void SplitWord(string word)
        {
            var result = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (char.IsUpper(word[i]) && i != 0)
                    result.Append(" ");

                if (char.IsLetter(word[i]))
                    result.Append(char.ToLower(word[i]));
            }

            Console.WriteLine(result.ToString());
        }

        public static void CombineWord(string word, string secondOperator)
        {
            var result = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                    result.Append(char.ToUpper(word[++i]));
                else
                    result.Append(word[i]);
            }

            if (secondOperator.Equals("M", StringComparison.OrdinalIgnoreCase))
                result.Append("()");
            else if (secondOperator.Equals("C", StringComparison.OrdinalIgnoreCase))
                result[0] = char.ToUpper(result[0]);
            else if (secondOperator.Equals("V", StringComparison.OrdinalIgnoreCase))
                result[0] = char.ToLower(result[0]);
            else
                throw new ArgumentException("Unknown Second operator.");

            Console.WriteLine(result.ToString());
        }
    }
}