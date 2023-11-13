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
            return 0;
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