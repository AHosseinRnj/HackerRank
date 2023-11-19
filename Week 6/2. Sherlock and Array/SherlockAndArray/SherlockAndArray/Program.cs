namespace SherlockAndArray
{
    class Result
    {

        /*
         * Complete the 'balancedSums' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static string balancedSums(List<int> arr)
        {
            Validate(arr);

            if (arr.Count == 1)
                return "YES";

            var leftSum = 0;
            var rightSum = arr.Skip(1).Sum();

            if (leftSum == rightSum)
                return "YES";

            for (int i = 0; i < arr.Count - 1; i++)
            {

                leftSum += arr[i];
                rightSum -= arr[i + 1];

                if (leftSum == rightSum)
                    return "YES";
            }

            return "NO";
        }

        private static void Validate(List<int> arr)
        {
            var arrayCount = arr.Count;
            if (arrayCount < 1 || arrayCount > Math.Pow(10, 5))
                throw new ArgumentException("Array length should be between 1 and 10^5", nameof(arrayCount));

            if (arr.Any(val => val < 0 || val > 2 * Math.Pow(10, 4)))
                throw new ArgumentException("Each array elements should be between 0 and 2 * 10^4", nameof(arr));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int T = Convert.ToInt32(Console.ReadLine().Trim());

            for (int TItr = 0; TItr < T; TItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                string result = Result.balancedSums(arr);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}