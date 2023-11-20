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
            Validate(grid);

            var result = "YES";

            for (int i = 0; i < grid.Count; i++)
            {
                var sortedRow = string.Concat(grid[i].OrderBy(chr => chr));
                grid[i] = sortedRow;
            }

            var columns = TransposeStrings(grid);

            if (columns.Any(item => item != string.Concat(item.OrderBy(chr => chr))))
                result = "NO";

            return result;
        }

        static List<string> TransposeStrings(List<string> inputStrings)
        {
            List<string> transposedStrings = new List<string>();

            int maxLength = inputStrings.Max(s => s.Length);

            List<string> paddedStrings = inputStrings.Select(s => s.PadRight(maxLength)).ToList();

            for (int i = 0; i < maxLength; i++)
                transposedStrings.Add(new string(paddedStrings.Select(s => s[i]).ToArray()));

            return transposedStrings;
        }

        private static void Validate(List<string> grid)
        {
            var numOfRows = grid.Count;
            //if (grid.Any(row => numOfRows != row.Length))
            //    throw new ArgumentException("Input matrix should be Square", nameof(grid));

            if (numOfRows < 1 || numOfRows > 100)
                throw new ArgumentException("Number of rows should be between 1 and 100 ", nameof(numOfRows));

            if (grid.Any(row => !row.Any(char.IsLower)))
                throw new ArgumentException("All characters in the grid should be lowercase.", nameof(grid));
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