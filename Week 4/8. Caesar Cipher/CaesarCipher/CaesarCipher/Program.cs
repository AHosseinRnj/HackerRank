using System.Text;

namespace CaesarCipher
{
    class Result
    {

        /*
         * Complete the 'caesarCipher' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. STRING s
         *  2. INTEGER k
         */

        public static string caesarCipher(string s, int k)
        {
            Validate(s, k);

            var strBuilder = new StringBuilder(s.Length);

            foreach (var character in s)
            {
                if (char.IsLetter(character))
                {
                    var baseChar = char.IsUpper(character) ? 'A' : 'a';
                    var shiftedLetter = (char)(baseChar + (character - baseChar + k) % 26);
                    strBuilder.Append(shiftedLetter);
                }
                else
                    strBuilder.Append(character);
            }

            return strBuilder.ToString();
        }

        private static void Validate(string s, int k)
        {
            if (k < 0 || k > 100)
                throw new ArgumentException("Variable should be between 0 and 100", nameof(k));

            if (s.Any(chr => char.IsWhiteSpace(chr)))
                throw new ArgumentException("The input should not contain spaces", nameof(s));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string s = Console.ReadLine();

            int k = Convert.ToInt32(Console.ReadLine().Trim());

            string result = Result.caesarCipher(s, k);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}