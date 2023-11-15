using System.Numerics;

namespace MockTest
{
    class Result
    {

        /*
         * Complete the 'fibonacciModified' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER t1
         *  2. INTEGER t2
         *  3. INTEGER n
         */

        public static BigInteger fibonacciModified(int t1, int t2, int n)
        {
            Validate(t1, t2, n);

            BigInteger temp1 = t1;
            BigInteger temp2 = t2;
            BigInteger nextT = 0;

            for (int i = 0; i < n - 2; i++)
            {
                nextT = temp1 + (temp2 * temp2);
                temp1 = temp2;
                temp2 = nextT;
            }

            return nextT;
        }

        private static void Validate(int t1, int t2, int n)
        {
            if (t1 < 0 || t1 > 2)
                throw new ArgumentException("Invalid value, Must be between 0 and 2.", nameof(t1));

            if (t2 < 0 || t2 > 2)
                throw new ArgumentException("Invalid value, Must be between 0 and 2.", nameof(t2));

            if (n < 3 || n > 20)
                throw new ArgumentException("Invalid value, Must be between 3 and 20.", nameof(n));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int t1 = Convert.ToInt32(firstMultipleInput[0]);

            int t2 = Convert.ToInt32(firstMultipleInput[1]);

            int n = Convert.ToInt32(firstMultipleInput[2]);

            var result = Result.fibonacciModified(t1, t2, n);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}