namespace TheFullCountingSort
{
    class Result
    {

        /*
         * Complete the 'countSort' function below.
         *
         * The function accepts 2D_STRING_ARRAY arr as parameter.
         */

        public static void countSort(List<List<string>> arr)
        {

        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<string>> arr = new List<List<string>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
            }

            Result.countSort(arr);
        }
    }
}