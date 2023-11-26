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
            return 0;
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
        }
    }
}