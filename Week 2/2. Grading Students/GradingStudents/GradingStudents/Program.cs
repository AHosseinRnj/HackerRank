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

namespace GradingStudents
{
    class Result
    {

        /*
         * Complete the 'gradingStudents' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts INTEGER_ARRAY grades as parameter.
         */

        public static List<int> gradingStudents(List<int> grades)
        {
            Validate(grades);

            var result = new List<int>();

            foreach (var grade in grades)
            {
                if (grade >= 38)
                    result.Add(CalculateNewGrade(grade));
                else
                    result.Add(grade);
            }

            return result;
        }

        private static int CalculateNewGrade(int grade)
        {
            var nextMultipleOf5 = Math.Round((double)(grade / 5)) * 5;

            if (nextMultipleOf5 < grade)
                nextMultipleOf5 += 5;

            if (nextMultipleOf5 - grade < 3)
                return (int)nextMultipleOf5;
            else
                return grade;
        }

        private static void Validate(List<int> grades)
        {
            /// 1 <= n <= 60
            if (grades.Count < 1 || grades.Count > 60)
                throw new ArgumentException("Count of array elements must be between 1 and 60");

            /// 0 <= grades[i] <= 100
            if (grades.Any(grade => grade < 0 || grade > 100))
                throw new ArgumentException("Each array element must be between 0 and 100");

            /*
            foreach (var grade in grades)
            {
                if (grade < 0 || grade > 100)
                    throw new ArgumentException("Each array element must be between 0 and 100");
            }
            */
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int gradesCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> grades = new List<int>();

            for (int i = 0; i < gradesCount; i++)
            {
                int gradesItem = Convert.ToInt32(Console.ReadLine().Trim());
                grades.Add(gradesItem);
            }

            List<int> result = Result.gradingStudents(grades);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}