using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XORStrings3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstString = Console.ReadLine();
            var secondString = Console.ReadLine();

            var result = Result.strings_xor(firstString, secondString);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    public class Result
    {
        public static string strings_xor(string first, string second)
        {
            Validate(first, second);

            var strBuilder = new StringBuilder(first.Length);

            for (int i = 0; i < first.Length; i++)
                strBuilder.Append(first[i] ^ second[i]);

            return strBuilder.ToString();
        }

        private static void Validate(string first, string second)
        {
            if (first.Length != second.Length)
                throw new ArgumentException("Length of two strings must be equal");

            if (first.Length < 1 || first.Length > Math.Pow(10, 4))
                throw new ArgumentException("First array length should be between 1 and 10^4", nameof(first));

            if (second.Length < 1 || second.Length > Math.Pow(10, 4))
                throw new ArgumentException("Second array length should be between 1 and 10^4", nameof(second));

            if (first.Any(ch => ch != '0' && ch != '1'))
                throw new ArgumentException("Each array elements must be 0 or 1", nameof(first));

            if (second.Any(ch => ch != '0' && ch != '1'))
                throw new ArgumentException("Each array elements must be 0 or 1", nameof(second));
        }
    }
}