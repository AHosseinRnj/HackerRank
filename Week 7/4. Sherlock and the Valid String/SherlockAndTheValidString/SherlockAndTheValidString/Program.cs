namespace SherlockAndTheValidString
{
    class Result
    {

        /*
         * Complete the 'isValid' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string isValid(string s)
        {
            Validate(s);

            var charFreq = new Dictionary<char, int>();
            foreach (var character in s)
            {
                if (charFreq.ContainsKey(character))
                    charFreq[character]++;
                else
                    charFreq[character] = 1;
            }

            var freqCount = new Dictionary<int, int>();
            foreach (int count in charFreq.Values)
            {
                if (freqCount.ContainsKey(count))
                    freqCount[count]++;
                else
                    freqCount[count] = 1;
            }

            if (freqCount.Count == 1)
                return "YES";

            if (freqCount.Count == 2)
            {
                var maxKey = freqCount.Keys.Max();
                var minKey = freqCount.Keys.Min();

                if (freqCount[maxKey] == 1 && maxKey - minKey == 1)
                    return "YES";
                else if (freqCount[minKey] == 1)
                    return "YES";
                else
                    return "NO";
            }

            return "NO";
        }

        private static void Validate(string s)
        {
            if (s.Length < 1 || s.Length > Math.Pow(10, 5))
                throw new ArgumentException("The length of input must be between 1 and 10^5", nameof(s));

            if (s.Any(chr => !char.IsLower(chr)))
                throw new ArgumentException("Each chracter must be ascii[a-z]", nameof(s));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string s = Console.ReadLine();

            string result = Result.isValid(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}