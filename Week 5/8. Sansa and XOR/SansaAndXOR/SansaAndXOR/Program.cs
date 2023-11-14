namespace SansaAndXOR
{
    class Result
    {

        /*
         * Complete the 'sansaXor' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static int sansaXor(List<int> arr)
        {
            Validate(arr);

            var arrayCount = arr.Count;
            if (arrayCount % 2 == 0)
                return 0;

            var result = 0;
            for (var index = 0; index < arrayCount; index++)
            {
                if (index % 2 == 0)
                    result = result ^ arr[index];
            }

            return result;
        }

        private static void Validate(List<int> arr)
        {
            var arrayCount = arr.Count;
            if (arrayCount < 2 || arrayCount > Math.Pow(10, 5))
                throw new ArgumentException("nvalid array count. The count must be between 2 and 10^5", nameof(arrayCount));

            if (arr.Any(val => val < 1 || val > Math.Pow(10, 8)))
                throw new ArgumentException("Invalid array element. All array elements must be between 1 and 10^8", nameof(arr));
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

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                int result = Result.sansaXor(arr);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}