namespace GoodlandElectricity
{
    class Result
    {

        /*
         * Complete the 'pylons' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER k
         *  2. INTEGER_ARRAY arr
         */

        public static int pylons(int k, List<int> arr)
        {
            Validate(k, arr);

            var index = 0;
            var numOfPlants = 0;
            var length = arr.Count;

            while (index < length)
            {
                var isFound = false;
                var start = index + k - 1;
                var end = index - k + 1;

                for (int j = start; j >= end; j--)
                {
                    if (IsValidIndex(j, length) && arr[j] == 1)
                    {
                        numOfPlants++;
                        index = j + k;
                        isFound = true;
                        break;
                    }
                }

                if (!isFound)
                    return -1;
            }

            return numOfPlants;
        }

        private static bool IsValidIndex(int index, int length)
        {
            return (index >= 0 && index < length);
        }

        private static void Validate(int k, List<int> arr)
        {
            if (k < 1 || k > Math.Pow(10, 5))
                throw new ArgumentException("Distributed Range must be between 1 and 10^5", nameof(k));

            if (arr.Count < 1 || arr.Count > Math.Pow(10, 5))
                throw new ArgumentException("Array Length must be between 1 and 10^5", nameof(arr.Count));

            if (arr.Any(val => val < 0 && val > 1))
                throw new ArgumentException("Each array elements must be 0 or 1", nameof(arr));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.pylons(k, arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}