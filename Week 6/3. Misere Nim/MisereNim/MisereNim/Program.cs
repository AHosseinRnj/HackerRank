namespace MisereNim
{
    class Result
    {

        /*
         * Complete the 'misereNim' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts INTEGER_ARRAY s as parameter.
         */

        /// https://en.wikipedia.org/wiki/Nim
        public static string misereNim(List<int> s)
        {
            Validate(s);

            var arraySum = s.Sum();
            var arraySize = s.Count();

            // If all elements are 1
            if (arraySum == arraySize)
                return (arraySize % 2 == 0) ? "First" : "Second";
            else
            {
                var xor = 0;
                foreach (var stoneSize in s)
                    xor ^= stoneSize;

                return xor > 0 ? "First" : "Second";
            }
        }

        private static void Validate(List<int> s)
        {
            if (s.Count < 1 || s.Count > 100)
                throw new ArgumentException("List Length should be between 1 and 100", nameof(s.Count));

            if (s.Any(val => val < 1 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Each list elements must be between 1 and 10^9", nameof(s));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

                string result = Result.misereNim(s);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}