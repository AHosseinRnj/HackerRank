namespace NewYearChaos
{
    class Result
    {

        /*
         * Complete the 'minimumBribes' function below.
         *
         * The function accepts INTEGER_ARRAY q as parameter.
         */

        public static void minimumBribes(List<int> q)
        {
            Validate(q);

            var swapCount = 0;
            for (int i = q.Count - 1; i >= 0; i--)
            {
                if (q[i] != i + 1)
                {
                    if (q[i - 1] == i + 1)
                    {
                        swapCount++;
                        Swap(q, i, i - 1);
                    }
                    else if (q[i - 2] == i + 1)
                    {
                        swapCount += 2;
                        Swap(q, i - 2, i - 1);
                        Swap(q, i - 1, i);
                    }
                    else
                    {
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }
            }

            Console.WriteLine(swapCount);
        }

        private static void Swap(List<int> q, int firstIndex, int secondIndex)
        {
            int temp = q[firstIndex];
            q[firstIndex] = q[secondIndex];
            q[secondIndex] = temp;
        }

        private static void Validate(List<int> q)
        {
            if (q.Count < 1 || q.Count > Math.Pow(10, 5))
                throw new ArgumentException("Array length should be between 1 and 10^5", nameof(q));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

                Result.minimumBribes(q);
            }
        }
    }
}