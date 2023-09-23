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
            arr.Sort();

            return arr[arr.Count / 2];
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