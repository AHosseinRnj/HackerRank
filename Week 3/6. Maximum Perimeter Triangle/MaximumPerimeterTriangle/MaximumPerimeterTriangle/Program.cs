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

namespace MaximumPerimeterTriangle
{
    class Result
    {

        /*
         * Complete the 'maximumPerimeterTriangle' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY sticks as parameter.
         */

        public static List<int> maximumPerimeterTriangle(List<int> sticks)
        {
            Validate(sticks);

            sticks.Sort();

            var result = new List<int>();
            var listOfVertices = new List<List<int>>();

            for (int i = 0; i < sticks.Count - 2; i++)
            {
                var firstSide = sticks[i];
                var secondSide = sticks[i + 1];
                var thirdSide = sticks[i + 2];

                if (firstSide + secondSide > thirdSide)
                {
                    var vertices = new List<int>() { firstSide, secondSide, thirdSide };
                    listOfVertices.Add(vertices);
                }
            }

            if (listOfVertices.Count == 0)
            {
                result.Add(-1);
                return result;
            }

            return listOfVertices.LastOrDefault();
        }

        private static void Validate(List<int> sticks)
        {
            if (sticks.Count < 3 || sticks.Count > 50)
                throw new ArgumentException("Length of array should be between 3 and 50", nameof(sticks));

            if (sticks.Any(val => val < 1 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Each array elements should be between 1 and 10^9", nameof(sticks));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> sticks = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sticksTemp => Convert.ToInt32(sticksTemp)).ToList();

            List<int> result = Result.maximumPerimeterTriangle(sticks);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}