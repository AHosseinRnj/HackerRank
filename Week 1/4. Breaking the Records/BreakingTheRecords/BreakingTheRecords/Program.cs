using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace BreakingTheRecords
{
    class Result
    {

        /*
         * Complete the 'breakingRecords' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY scores as parameter.
         */

        public static List<int> breakingRecords(List<int> scores)
        {
            var maxScore = scores[0];
            var minScore = scores[0];

            var maxCount = 0;
            var minCount = 0;

            /// With for Loop

            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > maxScore)
                {
                    maxScore = scores[i];
                    maxCount++;
                }
                else if (scores[i] < minScore)
                {
                    minScore = scores[i];
                    minCount++;
                }
            }

            /// With LINQ

            /*
            maxCount = scores.Skip(1).Distinct().Count(s =>
            {
                if (s > maxScore)
                {
                    maxScore = s;
                    return true;
                }
                return false;
            });

            minCount = scores.Skip(1).Distinct().Count(s =>
            {
                if (s > minScore)
                {
                    minScore = s;
                    return true;
                }
                return false;
            });
            */

            var result = new List<int>() { maxCount, minCount };
            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("C:\\Users\\AmirHossein\\Desktop\\test\\text.txt", true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> scores = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(scoresTemp => Convert.ToInt32(scoresTemp)).ToList();

            List<int> result = Result.breakingRecords(scores);

            textWriter.WriteLine(String.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}