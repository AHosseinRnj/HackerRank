﻿namespace TheFullCountingSort
{
    class IndexValuePair
    {
        public readonly int Index;
        public readonly string Value;

        public IndexValuePair(int index, string value)
        {
            Index = index;
            Value = value;
        }
    }

    class Result
    {

        /*
         * Complete the 'countSort' function below.
         *
         * The function accepts 2D_STRING_ARRAY arr as parameter.
         */

        public static void countSort(List<List<string>> arr)
        {
            Validate(arr);

            var mid = arr.Count / 2;
            var pair = new List<IndexValuePair>();

            for (int i = 0; i < arr.Count; i++)
            {
                var index = int.Parse(arr[i][0]);
                var value = arr[i][1];

                if (i < mid)
                    pair.Add(new IndexValuePair(index, "-"));
                else
                    pair.Add(new IndexValuePair(index, value));
            }

            var result = pair.OrderBy(pair => pair.Index).Select(pair => pair.Value);
            var output = string.Join(" ", result);

            Console.WriteLine(output);
        }

        private static void Validate(List<List<string>> arr)
        {
            var arrCount = arr.Count;
            if (arrCount % 2 != 0)
                throw new ArgumentException("The number of pairs must be even", nameof(arrCount));

            if (arrCount < 1 || arrCount > 1000000)
                throw new ArgumentException("The number of pairs must be between 1 and 1000000", nameof(arrCount));

            for (int i = 0; i < arrCount; i++)
            {
                var number = int.Parse(arr[i][0]);
                var characters = arr[i][1];

                if (number < 0 || number > 100)
                    throw new ArgumentException("The integer value must be between 0 and 100", nameof(number));

                if (characters.Length < 1 || characters.Length > 10)
                    throw new ArgumentException("he length of each string must be between 1 and 10", nameof(characters));

                if (!characters.Any(char.IsLower))
                    throw new ArgumentException("Each string must consist of lowercase letters only", nameof(characters));
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<string>> arr = new List<List<string>>();

            for (int i = 0; i < n; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
            }

            Result.countSort(arr);
        }
    }
}