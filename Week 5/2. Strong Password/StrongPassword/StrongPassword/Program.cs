using System.Runtime.InteropServices;

namespace StrongPassword
{
    class Result
    {

        /*
         * Complete the 'minimumNumber' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. STRING password
         */

        public static int minimumNumber(int n, string password)
        {
            Validate(n, password);

            int result = 0;

            if (!password.Any(char.IsDigit))
                result++;
            if (!password.Any(char.IsLower))
                result++;
            if (!password.Any(char.IsUpper))
                result++;
            if (!password.Any(c => char.IsPunctuation(c) || char.IsSymbol(c)))
                result++;

            if (result + n < 6)
                result = 6 - n;

            return result;
        }

        private static void Validate(int n, string password)
        {
            if (n < 1 || n > 100)
                throw new ArgumentException("n Should be between 1 and 100", nameof(n));

            if (password.Length < 1 || password.Length > 100)
                throw new ArgumentException("Password Length should be between 1 and 100", nameof(password.Length));

            if (password.Any(val => !char.IsLetter(val) && !char.IsDigit(val) && !char.IsPunctuation(val) && !char.IsSymbol(val)))
                throw new ArgumentException("Only Letters, Digits and symbols are Valid", nameof(password));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string password = Console.ReadLine();

            int answer = Result.minimumNumber(n, password);

            textWriter.WriteLine(answer);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}