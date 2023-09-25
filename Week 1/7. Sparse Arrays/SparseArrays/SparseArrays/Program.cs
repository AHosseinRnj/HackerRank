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

namespace SparseArrays
{
    class Result
    {

        /*
         * Complete the 'matchingStrings' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. STRING_ARRAY strings
         *  2. STRING_ARRAY queries
         */

        public static List<int> matchingStrings(List<string> strings, List<string> queries)
        {
            ValidateParameters(strings, queries);

            /// O(N^2)

            /*
            var count = 0;
            var result = new List<int>();

            foreach (var query in queries)
            {
                count = 0;
                foreach (var str in strings)
                {
                    if(query == str)
                        count++;
                }

                result.Add(count);
            }   
            */

            /// O(N) || (N + N)

            var result = new List<int>();
            var countDictionary = new Dictionary<string, int>();

            foreach (var str in strings)
            {
                if (countDictionary.ContainsKey(str))
                    countDictionary[str]++;
                else
                    countDictionary[str] = 1;
            }

            foreach (var query in queries)
            {
                if (countDictionary.ContainsKey(query))
                    result.Add(countDictionary[query]);
                else
                    result.Add(0);
            }

            return result;
        }

        private static void ValidateParameters(List<string> strings, List<string> queries)
        {
            /// 1 <= n <= 1000, where n is strings.Count
            if (strings.Count < 1 || strings.Count > 1000)
                throw new ArgumentException("Count of arrays elements must be between 1 and 1000");

            /// 1 <= q <= 1000, where q is queries.Count
            if (queries.Count < 1 || queries.Count > 1000)
                throw new ArgumentException("Count of arrays elements must be between 1 and 1000");

            /// 1 <= strings[i], queries[i] <= 20
            foreach (var str in strings)
            {
                if (str.Length < 1 || str.Length > 20)
                    throw new ArgumentException("Each string length should be between 1 and 20");
            }

            foreach (var query in queries)
            {
                if (query.Length < 1 || query.Length > 20)
                    throw new ArgumentException("Each query length should be between 1 and 20");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int stringsCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> strings = new List<string>();

            for (int i = 0; i < stringsCount; i++)
            {
                string stringsItem = Console.ReadLine();
                strings.Add(stringsItem);
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> queries = new List<string>();

            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = Console.ReadLine();
                queries.Add(queriesItem);
            }

            List<int> res = Result.matchingStrings(strings, queries);

            textWriter.WriteLine(String.Join("\n", res));

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}