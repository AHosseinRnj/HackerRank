namespace PickingNumbers
{
    class Result
    {

        /*
         * Complete the 'pickingNumbers' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY a as parameter.
         */

        public static int pickingNumbers(List<int> a)
        {
            Validate(a);

            a.Sort();

            var maxLenght = 0;
            var freqMap = new Dictionary<int, int>();

            foreach (var number in a)
            {
                if (freqMap.ContainsKey(number))
                    freqMap[number]++;
                else
                    freqMap[number] = 1;
            }

            foreach (var number in freqMap.Keys)
            {
                var currLenght = freqMap[number];

                if (freqMap.ContainsKey(number + 1))
                    currLenght += freqMap[number + 1];

                maxLenght = Math.Max(maxLenght, currLenght);
            }

            return maxLenght;


            //var max = int.MinValue;
            //for (int i = 0; i < a.Count; i++)
            //{
            //    var countOfFirstElement = a.Where(val => val == i).Count();
            //    var countOfSecondElement = a.Where(val => val == i - 1).Count();
            //    var total = countOfFirstElement + countOfSecondElement;

            //    if(total > max)
            //        max = total;
            //}

            //return max;
        }

        private static void Validate(List<int> a)
        {
            if (a.Count < 2 || a.Count > 100)
                throw new ArgumentException("Array size should be between 2 and 100", nameof(a.Count));

            if (a.Any(val => val < 0 || val > 100))
                throw new ArgumentException("Each array elements should be between 0 and 100", nameof(a));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

            int result = Result.pickingNumbers(a);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}