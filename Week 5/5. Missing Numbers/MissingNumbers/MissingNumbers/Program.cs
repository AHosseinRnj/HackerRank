namespace MissingNumbers
{
    class Result
    {

        /*
         * Complete the 'missingNumbers' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY arr
         *  2. INTEGER_ARRAY brr
         */

        public static List<int> missingNumbers(List<int> arr, List<int> brr)
        {
            Validate(arr, brr);

            var result = new List<int>();
            var arrFreqMap = new Dictionary<int, int>();
            var brrFreqMap = new Dictionary<int, int>();

            foreach (var num in brr)
            {
                if (brrFreqMap.ContainsKey(num))
                    brrFreqMap[num]++;
                else
                    brrFreqMap[num] = 1;
            }

            foreach (var num in arr)
            {
                if (arrFreqMap.ContainsKey(num))
                    arrFreqMap[num]++;
                else
                    arrFreqMap[num] = 1;
            }

            foreach (var num in brr)
            {
                if (!arrFreqMap.ContainsKey(num) || brrFreqMap[num] != arrFreqMap[num])
                    result.Add(num);
            }

            result = result.Distinct().ToList();
            result.Sort();

            return result;
        }

        public static void Validate(List<int> arr, List<int> brr)
        {
            var arrLength = arr.Count;
            var brrLength = brr.Count;

            if (arrLength < 1 || arrLength > 2 * Math.Pow(10, 5))
                throw new ArgumentException("The length of array should be betwwen 1 and 2 * 10^5", nameof(arr));

            if (brrLength < 1 || brrLength > 2 * Math.Pow(10, 5))
                throw new ArgumentException("The length of array should be betwwen 1 and 2 * 10^5", nameof(brr));

            if (arrLength > brrLength)
                throw new ArgumentException("First array length should be less than or equal to the second array length.", nameof(arr));

            if (brr.Max() - brr.Min() > 100)
                throw new ArgumentException("The range of values in the array should be less than or equal to 100", nameof(brr));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int m = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

            List<int> result = Result.missingNumbers(arr, brr);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}