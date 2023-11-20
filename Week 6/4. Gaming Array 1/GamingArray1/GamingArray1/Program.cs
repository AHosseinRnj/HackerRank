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
            return string.Empty;
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