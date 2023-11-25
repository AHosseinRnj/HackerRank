namespace RecursiveDigitSum
{
    class Result
    {

        /*
         * Complete the 'superDigit' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. STRING n
         *  2. INTEGER k
         */

        public static long superDigit(string n, int k)
        {
            Validate(n, k);

            /*
            long initialNum = 0;
            foreach (var number in n)
                initialNum += long.Parse(number.ToString());

            long superNum = initialNum * k;
            while (superNum > 9)
            {
                long sum = 0;
                foreach (var number in superNum.ToString())
                    sum += long.Parse(number.ToString());

                superNum = sum;
            }

            return superNum;
            */

            /*
            long sum = (long)n.Select(char.GetNumericValue).Sum() * k;

            while (sum > 9)
                sum = (long)sum.ToString().Select(char.GetNumericValue).Sum();
            
            return sum;
            */

            var initialNum = (long)n.Select(char.GetNumericValue).Sum() * k;
            Console.WriteLine($"initialNum : {initialNum}");

            var result = CalculateDigit(initialNum);

            return result;
        }

        private static long CalculateDigit(long n)
        {
            if (n <= 9)
                return n;

            Console.WriteLine($"n : {n}");
            var sum = (long)n.ToString().Select(char.GetNumericValue).Sum();
            return CalculateDigit(sum);
        }

        private static void Validate(string n, int k)
        {
            if (k < 1 || k > Math.Pow(10, 5))
                throw new ArgumentException("The value of 'k' must be between 1 and 10^5", nameof(k));

            if (n.Length < 1 || n.Length > Math.Pow(10, 100000))
                throw new ArgumentException("The length of 'n' must be between 1 and 10^100000", nameof(n));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            string n = firstMultipleInput[0];

            int k = Convert.ToInt32(firstMultipleInput[1]);

            long result = Result.superDigit(n, k);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}