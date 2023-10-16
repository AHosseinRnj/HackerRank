using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigZagSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// In this challenge, the task is to debug the existing code to successfully execute all provided test files.
        }

        public static void FindZigZagSequence(int[] a, int n)
        {
            Array.Sort(a);
            var mid = n / 2;
            var temp = a[mid];
            a[mid] = a[n - 1];
            a[n - 1] = temp;

            var st = mid + 1;
            var ed = n - 2;
            while (st <= ed)
            {
                temp = a[st];
                a[st] = a[ed];
                a[ed] = temp;
                st++;
                ed--;
            }
            for (int i = 0; i < n; i++)
            {
                if (i > 0)
                    Console.Write(" ");
                Console.WriteLine(a[i]);
            }
            Console.WriteLine();
        }
    }
}