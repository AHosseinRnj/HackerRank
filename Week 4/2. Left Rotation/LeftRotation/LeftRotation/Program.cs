namespace LeftRotation
{
    class Result
    {

        /*
         * Complete the 'rotateLeft' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER d
         *  2. INTEGER_ARRAY arr
         */

        public static List<int> rotateLeft(int d, List<int> arr)
        {
            Validate(d, arr);

            // 1st Way O(N + N):
            /*
            var tempList = new List<int>();
            for (int i = d; i < arr.Count; i++)
                tempList.Add(arr[i]);

            for (int i = 0; i < d; i++)
                tempList.Add(arr[i]);

            return tempList;
            */

            // 2nd Way O(d * N) - ** Time limit **:
            var shiftCount = 1;
            var totalShift = d;

            while (shiftCount <= totalShift)
            {
                var firstElement = arr[0];
                for (var i = 0; i < arr.Count - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[arr.Count - 1] = firstElement;
                shiftCount++;
            }

            return arr;
        }

        private static void Validate(int d, List<int> arr)
        {
            if (arr.Count < 1 || arr.Count > Math.Pow(10, 5))
                throw new ArgumentException("Array length should be between 1 and 10^5", nameof(arr.Count));

            if (d < 1 || d > arr.Count)
                throw new ArgumentException("The amount to rotate, should be between 1 and n", nameof(d));

            if (arr.Any(val => val < 1 || val > Math.Pow(10, 6)))
                throw new ArgumentException("Each array elements must be between 1 and 10^6");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int d = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.rotateLeft(d, arr);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}