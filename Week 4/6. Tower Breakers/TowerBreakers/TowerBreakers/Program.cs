namespace TowerBreakers
{
    class Result
    {

        /*
         * Complete the 'towerBreakers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. INTEGER m
         */

        public static int towerBreakers(int n, int m)
        {
            Validate(n, m);

            if (m == 1 || n % 2 == 0)
                return 2;
            else
                return 1;
        }

        private static void Validate(int n, int m)
        {
            if (n < 1 || n > Math.Pow(10, 6))
                throw new ArgumentException("Variable n, should be between 1 and 10^6", nameof(n));

            if (m < 1 || m > Math.Pow(10, 6))
                throw new ArgumentException("Variable m, should be between 1 and 10^6", nameof(m));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                int n = Convert.ToInt32(firstMultipleInput[0]);

                int m = Convert.ToInt32(firstMultipleInput[1]);

                int result = Result.towerBreakers(n, m);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}