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

namespace TimeConversion
{
    class Result
    {

        /*
         * Complete the 'timeConversion' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts STRING s as parameter.
         */

        public static string timeConversion(string s)
        {
            /// Using DateTime :

            /*
            DateTime dateTime;

            if (!DateTime.TryParse(s, out dateTime))
                throw new ArgumentException("Invalid DateTime Format");

            return dateTime.TimeOfDay.ToString();
            */

            /// Without using DateTime :

            var input = s.Split(':');

            var hour = Convert.ToInt32(input[0]);
            var minute = Convert.ToInt32(input[1]);
            var second = Convert.ToInt32(input[2].Substring(0, 2));
            var meridiem = input[2].Substring(2, 2);

            if (meridiem.Equals("PM", StringComparison.OrdinalIgnoreCase) && hour != 12)
                hour += 12;
            else if (meridiem.Equals("AM", StringComparison.OrdinalIgnoreCase) && hour == 12)
                hour = 0;

            var result = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);

            return result;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("C:\\Users\\AmirHossein\\Desktop\\Test\\text.txt", true);

            string s = Console.ReadLine();

            string result = Result.timeConversion(s);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();

            Console.ReadLine();
        }
    }
}