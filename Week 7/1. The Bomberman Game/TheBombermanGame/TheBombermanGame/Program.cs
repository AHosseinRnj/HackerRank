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
            Validate(n, grid);

            if (n == 1)
                return grid;

            if (n % 2 == 0)
            {
                var result = Array.ConvertAll(grid.ToArray(), row => new string('O', row.Length));
                return new List<string>(result);
            }
            else if (n % 4 == 3)
            {
                return Bomb(grid);
            }
            else
            {
                return Bomb(Bomb(grid));
            }
        }

        private static List<string> Bomb(List<string> grid)
        {
            var fullGrid = new char[grid.Count][];

            for (int i = 0; i < grid.Count; i++)
            {
                fullGrid[i] = new char[grid[i].Length];
                Array.Fill(fullGrid[i], 'O');
            }

            for (int row = 0; row < fullGrid.Length; row++)
            {
                for (int col = 0; col < fullGrid[row].Length; col++)
                {
                    if (grid[row][col] == 'O')
                    {
                        fullGrid[row][col] = '.';

                        if (row + 1 < fullGrid.Length)
                            fullGrid[row + 1][col] = '.';

                        if (row - 1 >= 0)
                            fullGrid[row - 1][col] = '.';

                        if (col + 1 < fullGrid[row].Length)
                            fullGrid[row][col + 1] = '.';

                        if (col - 1 >= 0)
                            fullGrid[row][col - 1] = '.';
                    }
                }
            }

            var result = Array.ConvertAll(fullGrid, row => new string(row));
            return new List<string>(result);
        }

        private static void Validate(int n, List<string> grid)
        {
            if (n < 1 || n > Math.Pow(10, 9))
                throw new ArgumentException("Simulate time must be between 1 and 10^9", nameof(n));

            var numOfRows = grid.Count;
            if (numOfRows < 1 || numOfRows > 200)
                throw new ArgumentException("Number of rows must be between 1 and 200", nameof(n));

            if (grid.Any(cols => cols.Length < 1 || cols.Length > 200))
                throw new ArgumentException("Number of columns must be between 1 and 200", nameof(n));
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