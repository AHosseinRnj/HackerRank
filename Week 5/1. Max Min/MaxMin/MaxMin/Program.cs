namespace MaxMin
{
    class Result
    {

        /*
         * Complete the 'maxMin' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         */

        public static int maxMin(int k, List<int> arr)
        {
            Validate(k, arr);

            arr.Sort();
            var arrayLength = arr.Count;
            var minUnfairness = int.MaxValue;

            for (int i = 0; i <= arrayLength - k; i++)
            {
                // Max - Min
                var tempUnfairness = arr[i + k - 1] - arr[i];

                if (tempUnfairness < minUnfairness)
                    minUnfairness = tempUnfairness;
            }

            return minUnfairness;
        }

        private static void Validate(int k, List<int> arr)
        {
            var arraySize = arr.Count;
            if (arraySize < 2 || arraySize > Math.Pow(10, 5))
                throw new ArgumentException("Array size should be between 2 and 10^5", nameof(arraySize));

            if (k < 2 || k > arraySize)
                throw new ArgumentException("K, Should be between 2 and n", nameof(k));

            if (arr.Any(val => val < 0 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Each array elements must be between 0 and 10^9", nameof(arr));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int k = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
                arr.Add(arrItem);
            }

            int result = Result.maxMin(k, arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}