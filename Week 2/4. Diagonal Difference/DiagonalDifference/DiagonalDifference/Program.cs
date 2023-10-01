using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace DiagonalDifference
{
    class Result
    {

        /*
         * Complete the 'diagonalDifference' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts 2D_INTEGER_ARRAY arr as parameter.
         */

        public static int diagonalDifference(List<List<int>> matrixArray)
        {
            Validate(matrixArray);

            var index = 0;
            var ltrDiagonal = 0;
            var rtlDiagonal = 0;
            var lastIndex = matrixArray.Count - 1;

            foreach (var row in matrixArray)
            {
                ltrDiagonal += row[index];
                rtlDiagonal += row[lastIndex - index];

                index++;
            }

            var result = Math.Abs(ltrDiagonal - rtlDiagonal);
            return result;
        }

        private static void Validate(List<List<int>> matrixArray)
        {
            if (matrixArray.Any(row => row.Any(val => val < -100 || val > 100)))
                throw new ArgumentException("Each matrix elements must be between -100 and 100");

            var numOfRows = matrixArray.Count;
            foreach (var row in matrixArray)
            {
                var numOfCol = row.Count;
                if (numOfRows != numOfCol)
                    throw new ArgumentException("Input matrix should be Square");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = Result.diagonalDifference(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}