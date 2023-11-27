namespace MockTest
{
    class Result
    {

        /*
         * Complete the 'palindromeIndex' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */

        public static int palindromeIndex(string s)
        {
            Validate(s);

            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (s[left] != s[right])
                    break;

                left++;
                right--;
            }

            if (left >= right)
                return -1;

            var tempLeft = left;
            var tempRight = right;

            left++;
            var leftFault = true;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    leftFault = false;
                    break;
                }

                left++;
                right--;
            }

            return leftFault ? tempLeft : tempRight;
        }

        private static void Validate(string s)
        {
            if (s.Length < 1 || s.Length > Math.Pow(10, 5) + 5)
                throw new ArgumentException("Input length should be between 1 and 10^5 + 5", nameof(s));

            if (s.Any(chr => !char.IsLower(chr)))
                throw new ArgumentException("Only lower case characters are valid", nameof(s));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = Result.palindromeIndex(s);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}