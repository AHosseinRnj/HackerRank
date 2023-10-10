using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace MockTest
{
    class Result
    {

        /*
         * Complete the 'flippingMatrix' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
         */

        /// Pattern : https://drive.google.com/uc?export=view&id=1t_7fU2LD06qfyIOiFTJ51X8npx0qmcca
        public static int flippingMatrix(List<List<int>> matrix)
        {
            Validate(matrix);

            var sum = 0;
            var Length = matrix.Count;

            for (int row = 0; row < Length / 2; row++)
            {
                for (int col = 0; col < Length / 2; col++)
                {
                    var topLeft = matrix[row][col];
                    var topRight = matrix[row][Length - col - 1];
                    var buttomLeft = matrix[Length - row - 1][col];
                    var buttomRight = matrix[Length - row - 1][Length - col - 1];

                    sum += GetMax(topLeft, topRight, buttomLeft, buttomRight);
                }
            }

            return sum;
        }

        private static int GetMax(params int[] values)
        {
            return values.Max();
        }

        private static void Validate(List<List<int>> matrix)
        {
            var numOfRows = matrix.Count;
            if (matrix.Any(row => numOfRows != row.Count))
                throw new ArgumentException("Input matrix should be Square");

            if (matrix.Any(row => numOfRows % 2 != 0 || row.Count % 2 != 0))
                throw new ArgumentException("Input matrix should be even");

            var n = numOfRows / 2;
            if (n < 1 || n > 128)
                throw new ArgumentException("n should be between 1 and 128", nameof(n));

            if (matrix.Any(row => row.Any(val => val < 0 || val > 4096)))
                throw new ArgumentException("Each matrix elements must be between 0 and 4096");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                int n = Convert.ToInt32(Console.ReadLine().Trim());

                List<List<int>> matrix = new List<List<int>>();

                for (int i = 0; i < 2 * n; i++)
                {
                    matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
                }

                int result = Result.flippingMatrix(matrix);

                textWriter.WriteLine(result);
            }

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}