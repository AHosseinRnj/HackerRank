using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SumVsXOR
{
    class Result
    {

        /*
         * Complete the 'sumXor' function below.
         *
         * The function is expected to return a LONG_INTEGER.
         * The function accepts LONG_INTEGER n as parameter.
         */

        public static long sumXor(long n)
        {
            Validate(n);

            /* Time Limit :
            var count = 0;
            if (n == 0)
                return ++count;

            for (int i = 0; i < n; i++)
            {
                var sum = n + i;
                var xor = n ^ i;

                if (sum == xor)
                    count++;
            }

            return count;
            */

            if (n == 0)
                return 1;

            var binaryRepresentation = Convert.ToString(n, 2);
            var zeroBitCount = binaryRepresentation.Count(bit => bit == '0');

            var result = (long)Math.Pow(2, zeroBitCount);
            return result;
        }

        private static void Validate(long n)
        {
            if (n < 0 || n > Math.Pow(10, 15))
                throw new ArgumentException("Input should be between 0 and 10^15", nameof(n));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            long n = Convert.ToInt64(Console.ReadLine().Trim());

            long result = Result.sumXor(n);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}