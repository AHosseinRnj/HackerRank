using System.Collections.Generic;

namespace FormingAMagicSquare
{
    class Result
    {

        /*
         * Complete the 'formingMagicSquare' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY s as parameter.
         */

        // https://www.rigb.org/explore-science/explore/blog/fascination-magic-squares
        public static int formingMagicSquare(List<List<int>> s)
        {
            Validate(s);

            /*
            List<List<List<int>>> collection = new List<List<List<int>>>()
            {
                new List<List<int>>() {new List<int>() {8, 1, 6}, new List<int>() {3, 5, 7}, new List<int>() {4, 9, 2}},
                new List<List<int>>() {new List<int>() {6, 1, 8}, new List<int>() {7, 5, 3}, new List<int>() {2, 9, 4}},
                new List<List<int>>() {new List<int>() {4, 9, 2}, new List<int>() {3, 5, 7}, new List<int>() {8, 1, 6}},
                new List<List<int>>() {new List<int>() {2, 9, 4}, new List<int>() {7, 5, 3}, new List<int>() {6, 1, 8}},
                new List<List<int>>() {new List<int>() {8, 3, 4}, new List<int>() {1, 5, 9}, new List<int>() {6, 7, 2}},
                new List<List<int>>() {new List<int>() {4, 3, 8}, new List<int>() {9, 5, 1}, new List<int>() {2, 7, 6}},
                new List<List<int>>() {new List<int>() {6, 7, 2}, new List<int>() {1, 5, 9}, new List<int>() {8, 3, 4}},
                new List<List<int>>() {new List<int>() {2, 7, 6}, new List<int>() {9, 5, 1}, new List<int>() {4, 3, 8}},
            };

            int min = int.MaxValue;
            foreach (var matrix in collection)
            {
                var cost = 0;

                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        cost += Math.Abs(s[i][j] - matrix[i][j]);

                min = Math.Min(min, cost);
            }

            return min;
            */

            List<List<int>> matrix = new List<List<int>>()
            {
                new List<int>() { 8, 1, 6 },
                new List<int>() { 3, 5, 7 },
                new List<int>() { 4, 9, 2 }
            };

            List<int> change = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                change.Add(Changes(s, matrix));
                var reflectedMatrix = ReflectMat(matrix);
                change.Add(Changes(s, reflectedMatrix));
                matrix = RotateBy90(matrix);
            }

            int minChange = change[0];
            for (int i = 1; i < 8; i++)
            {
                minChange = Math.Min(minChange, change[i]);
            }

            return minChange;
        }

        static List<List<int>> RotateBy90(List<List<int>> mat)
        {
            int n = mat.Count;
            List<List<int>> newMat = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                newMat.Add(new List<int>());
                for (int j = 0; j < n; j++)
                {
                    newMat[i].Add(mat[n - j - 1][i]);
                }
            }
            return newMat;
        }

        static List<List<int>> ReflectMat(List<List<int>> mat)
        {
            int n = mat.Count;
            List<List<int>> newMat = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                newMat.Add(new List<int>());
                for (int j = 0; j < n; j++)
                {
                    newMat[i].Add(mat[i][n - j - 1]);
                }
            }
            return newMat;
        }

        static int Changes(List<List<int>> mat1, List<List<int>> mat2)
        {
            int n = mat1.Count;
            int change = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    change += Math.Abs(mat1[i][j] - mat2[i][j]);
                }
            }
            return change;
        }

        private static void Validate(List<List<int>> s)
        {
            var numOfRows = s.Count;
            if (s.Any(row => numOfRows != row.Count))
                throw new ArgumentException("Input matrix should be Square", nameof(s));

            if (s.Any(row => row.Count != 3))
                throw new ArgumentException("Input matrix should be 3x3", nameof(s));

            if (s.Any(row => row.Any(num => num < 1 || num > Math.Pow(s.Count, 2))))
                throw new ArgumentException("Each element must be between 1 and n^2", nameof(s));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            List<List<int>> s = new List<List<int>>();

            for (int i = 0; i < 3; i++)
            {
                s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
            }

            int result = Result.formingMagicSquare(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}