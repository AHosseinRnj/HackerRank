namespace MinimumAbsoluteDifferenceInAnArray
{
    class Result
    {

        /*
         * Complete the 'minimumAbsoluteDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static int minimumAbsoluteDifference(List<int> arr)
        {
            Validate(arr);

            arr.Sort();

            var minDifference = Int32.MaxValue;
            for (int i = 0; i < arr.Count - 1; i++)
            {
                var firstNum = arr[i];
                var secondNum = arr[i + 1];

                var absoluteDifference = Math.Abs(firstNum - secondNum);

                if (absoluteDifference < minDifference)
                    minDifference = absoluteDifference;
            }

            return minDifference;
        }

        private static void Validate(List<int> arr)
        {
            if (arr.Count < 2 || arr.Count > Math.Pow(10, 5))
                throw new ArgumentException("Array length should be between 2 and 10^5", nameof(arr.Count));

            if (arr.Any(val => val < Math.Pow(-10, 9) || val > Math.Pow(10, 9)))
                throw new ArgumentException("Each array elements must be between -10^9 and 10^9", nameof(arr));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.minimumAbsoluteDifference(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}