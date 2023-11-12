namespace GridChallenge
{
    class Result
    {

        /*
         * Complete the 'gridChallenge' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING_ARRAY grid as parameter.
         */

        public static string gridChallenge(List<string> grid)
        {
            return string.Empty;
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

                List<string> grid = new List<string>();

                for (int i = 0; i < n; i++)
                {
                    string gridItem = Console.ReadLine();
                    grid.Add(gridItem);
                }

                string result = Result.gridChallenge(grid);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}