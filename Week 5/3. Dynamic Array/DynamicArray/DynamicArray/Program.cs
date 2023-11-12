namespace DynamicArray
{
    class Result
    {

        /*
         * Complete the 'dynamicArray' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY queries
         */

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            Validate(n, queries);

            var lastAnswer = 0;
            var lastAnswers = new List<int>();

            /*
            var seqList = new List<List<int>>();
            for (int i = 0; i < n; i++)
                seqList.Add(new List<int>());
            */

            var seqList = Enumerable.Range(0, n).Select(_ => new List<int>()).ToList();

            foreach (var query in queries)
            {
                var index = (query[1] ^ lastAnswer) % n;

                if (query.First() == 1)
                    seqList[index].Add(query.Last());
                else
                {
                    var y = query.Last();
                    var size = seqList[index].Count();

                    lastAnswer = seqList[index][y % size];
                    lastAnswers.Add(lastAnswer);
                }
            }

            return lastAnswers;
        }

        private static void Validate(int n, List<List<int>> queries)
        {
            if (n < 1 || n > Math.Pow(10, 5))
                throw new ArgumentException("Array size should be between 1 and 10^5", nameof(n));

            var queriesCount = queries.Count;
            if (queriesCount < 1 || queriesCount > Math.Pow(10, 5))
                throw new ArgumentException("Queries count should be between 1 and 10^5", nameof(queriesCount));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<List<int>> queries = new List<List<int>>();

            for (int i = 0; i < q; i++)
            {
                queries.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(queriesTemp => Convert.ToInt32(queriesTemp)).ToList());
            }

            List<int> result = Result.dynamicArray(n, queries);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}