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
            return 0;
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