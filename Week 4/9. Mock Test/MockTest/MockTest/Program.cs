namespace MockTest
{
    class Result
    {

        /*
         * Complete the 'anagram' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts STRING s as parameter.
         */

        public static int anagram(string s)
        {
            Validate(s);

            if (s.Length % 2 != 0)
                return -1;

            var result = 0;
            var mid = s.Length / 2;
            var dictionary = new Dictionary<char, int>();

            for (int i = 0; i < mid; i++)
            {
                if (dictionary.ContainsKey(s[i]))
                    dictionary[s[i]]++;
                else
                    dictionary[s[i]] = 1;
            }

            for (int i = mid; i < s.Length; i++)
            {
                if (dictionary.ContainsKey(s[i]) && dictionary[s[i]] > 0)
                    dictionary[s[i]]--;
                else
                    result++;
            }

            return result;
        }

        private static void Validate(string s)
        {
            if (s.Length < 1 || s.Length > Math.Pow(10, 4))
                throw new ArgumentException("The string length should be between 1 and 10^4", nameof(s));

            if (s.Any(val => !char.IsLetter(val)))
                throw new ArgumentException("Only Letters are allowed", nameof(s));
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

                int result = Result.anagram(s);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}