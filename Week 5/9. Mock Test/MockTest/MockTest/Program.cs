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

        public static int fibonacciModified(int t1, int t2, int n)
        {
            return 0;
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

            int result = Result.fibonacciModified(t1, t2, n);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}