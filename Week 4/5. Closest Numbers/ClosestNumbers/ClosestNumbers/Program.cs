namespace ClosestNumbers
{
    class Result
    {

        /*
         * Complete the 'closestNumbers' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static List<int> closestNumbers(List<int> arr)
        {
            Validate(arr);

            arr.Sort();

            var minDiffrence = Int32.MaxValue;
            var result = new List<int>();

            for (int i = 0; i < arr.Count - 1; i++)
            {
                var firstNumber = arr[i];
                var secondNumber = arr[i + 1];
                var diffrence = secondNumber - firstNumber;


                if (diffrence <= minDiffrence)
                {
                    if (diffrence < minDiffrence)
                        result.Clear();

                    minDiffrence = diffrence;

                    result.Add(firstNumber);
                    result.Add(secondNumber);
                }
            }

            return result;
        }

        private static void Validate(List<int> arr)
        {
            if (arr.Count < 2 || arr.Count > 200000)
                throw new ArgumentException("Array length Should be between 2 and 200000", nameof(arr.Count));

            if (arr.Any(val => val < Math.Pow(-10, 7) || val > Math.Pow(10, 7)))
                throw new ArgumentException("Each array elements must be between -10^7 and 10^7", nameof(arr));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.closestNumbers(arr);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}