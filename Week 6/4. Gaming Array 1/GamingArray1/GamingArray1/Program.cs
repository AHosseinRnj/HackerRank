namespace GamingArray1
{
    class Result
    {

        /*
         * Complete the 'gamingArray' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static string gamingArray(List<int> arr)
        {
            Validate(arr);

            /*
                - ANDY = 1
                - BOB = 2
            */

            /* Time Limit :
            var currentPlayer = 1;

            while (true)
            {
                var arrayLength = arr.Count;
                if (arrayLength == 0)
                    break;

                var maxElement = arr.Max();
                var maxElementIndex = arr.IndexOf(maxElement);
                var removeCount = arrayLength - maxElementIndex;

                arr.RemoveRange(maxElementIndex, removeCount);

                currentPlayer = currentPlayer == 1 ? 2 : 1;
            }

            if (currentPlayer == 1)
                return "ANDY";

            return "BOB";
            */

            var count = 1;
            var lastMax = arr[0];

            for (var i = 1; i < arr.Count; i++)
            {
                if (arr[i] > lastMax)
                {
                    lastMax = arr[i];
                    count++;
                }
            }

            if (count % 2 == 0)
                return "ANDY";

            return "BOB";
        }

        private static void Validate(List<int> arr)
        {
            if (arr.Count != arr.Distinct().Count())
                throw new ArgumentException("Array should not contains duplicates", nameof(arr));

            if (arr.Count < 1 || arr.Count > Math.Pow(10, 5))
                throw new ArgumentException("Array length should be between 1 and 10^5", nameof(arr));

            if (arr.Any(val => val < 1 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Each array elements must be between 1 and 10^9", nameof(arr));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int g = Convert.ToInt32(Console.ReadLine().Trim());

            for (int gItr = 0; gItr < g; gItr++)
            {
                int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

                string result = Result.gamingArray(arr);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();
        }
    }
}