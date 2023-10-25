namespace NumberLineJumps
{
    class Result
    {

        /*
         * Complete the 'kangaroo' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts following parameters:
         *  1. INTEGER x1
         *  2. INTEGER v1
         *  3. INTEGER x2
         *  4. INTEGER v2
         */

        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            Validate(x1, v1, x2, v2);

            /// 1st. Way:
            /*
            var firstAnimalLocation = x1;
            var secondAnimalLocation = x2;

            for (int i = x1; i <= x2; i++)
            {
                if (firstAnimalLocation == secondAnimalLocation)
                    return "YES";

                firstAnimalLocation += v1;
                secondAnimalLocation += v2;
            }

            return "NO";
            */

            /// 2nd. Way:
            if (v1 <= v2)
                return "NO";

            var relativeSpeed = v2 - v1;
            var relativeLocation = x2 - x1;
            if (relativeLocation % relativeSpeed >= 0)
                return "YES";
            else
                return "NO";
        }

        private static void Validate(int x1, int v1, int x2, int v2)
        {
            if (x2 < x1)
                throw new ArgumentException("x2 must be greater that x1");

            if (x2 < 0 || x2 > 10000)
                throw new ArgumentException("x2 should be between 0 and 10000", nameof(x2));

            if (x1 < 0 || x1 > 10000)
                throw new ArgumentException("x1 should be between 0 and 10000", nameof(x1));

            if (v1 < 1 || v1 > 10000)
                throw new ArgumentException("v1 should be between 1 and 10000", nameof(v1));

            if (v2 < 1 || v2 > 10000)
                throw new ArgumentException("v2 should be between 1 and 10000", nameof(v2));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int x1 = Convert.ToInt32(firstMultipleInput[0]);

            int v1 = Convert.ToInt32(firstMultipleInput[1]);

            int x2 = Convert.ToInt32(firstMultipleInput[2]);

            int v2 = Convert.ToInt32(firstMultipleInput[3]);

            string result = Result.kangaroo(x1, v1, x2, v2);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}