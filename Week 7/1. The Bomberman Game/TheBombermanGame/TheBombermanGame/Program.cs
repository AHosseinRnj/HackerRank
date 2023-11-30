namespace TheBombermanGame
{
    class Result
    {

        /*
         * Complete the 'bomberMan' function below.
         *
         * The function is expected to return a STRING_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. STRING_ARRAY grid
         */

        public static List<string> bomberMan(int n, List<string> grid)
        {
            return new List<string>();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(firstMultipleInput[0]);

            int c = Convert.ToInt32(firstMultipleInput[1]);

            int n = Convert.ToInt32(firstMultipleInput[2]);

            List<string> grid = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            List<string> result = Result.bomberMan(n, grid);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}