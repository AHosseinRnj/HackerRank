using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockTest
{
    class Result
    {
        /*
        * Complete the 'findMedian' function below.
        *
        * The function is expected to return an INTEGER.
        * The function accepts INTEGER_ARRAY arr as parameter.
        */

        public static int findMedian(List<int> arr)
        {
            Validate(arr);

            arr.Sort();

            return arr[arr.Count / 2];
        }

        private static void Validate(List<int> arr)
        {
            /// 1 <= n <= 1000001
            if (arr.Count < 1 || arr.Count > 1000001)
                throw new ArgumentException("Count of array elements must be between 1 and 1000001");

            /// n is odd
            if (arr.Count % 2 == 0)
                throw new ArgumentException("Count of array elemnts must be odd");

            /// -10000 <= arr[i] <= 10000
            foreach (var number in arr)
            {
                if (number < -10000 || number > 10000)
                    throw new ArgumentException("Each array element must be between -10000 and 10000");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.findMedian(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}