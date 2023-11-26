namespace CounterGame
{
    class Result
    {

        /*
         * Complete the 'counterGame' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts LONG_INTEGER n as parameter.
         */

        public static string counterGame(long n)
        {
            Validate(n);

            /* Time Limit :
            var number = n;
            var currentPlayer = 1;

            while (number > 1)
            {
                if (IsPowerOfTwo(number))
                    number = number / 2;
                else
                    number = n - NextPowerOfTwo(number);

                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }

            return currentPlayer == 1 ? "Richard" : "Louise";
            */

            var number = n;
            var currentPlayer = 1;

            while (number > 1)
            {
                if ((number & number - 1) == 0)
                    number = number / 2;
                else
                    number = number - NextPowerOfTwo(number);

                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }

            return currentPlayer == 1 ? "Richard" : "Louise";
        }

        private static bool IsPowerOfTwo(long n)
        {
            var logResult = Math.Log2(n);
            return Math.Floor(logResult) == logResult;
        }

        private static long NextPowerOfTwo(long n)
        {
            var power = Math.Log2(n);
            var result = (long)Math.Pow(2, Math.Floor(power));
            return result;
        }

        private static void Validate(long n)
        {
            if (n < 1 || n > Math.Pow(2, 64) - 1)
                throw new ArgumentException("input should be between 1 and 2^64 - 1", nameof(n));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                long n = Convert.ToInt64(Console.ReadLine().Trim());

                string result = Result.counterGame(n);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}