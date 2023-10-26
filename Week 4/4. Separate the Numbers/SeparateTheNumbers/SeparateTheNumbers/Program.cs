namespace SeparateTheNumbers
{
    class Result
    {

        /*
         * Complete the 'separateNumbers' function below.
         *
         * The function accepts STRING s as parameter.
         */

        public static void separateNumbers(string s)
        {
            Validate(s);

            var subString = string.Empty;

            for (int i = 1; i <= s.Length / 2; i++)
            {
                subString = s.Substring(0, i);
                var validString = subString;
                var number = Int64.Parse(subString);

                while (validString.Length < s.Length)
                    validString += (number += 1);

                if (s.Equals(validString))
                {
                    Console.WriteLine($"YES {subString}");
                    return;
                }
            }

            Console.WriteLine("NO");
        }

        private static void Validate(string s)
        {
            if (s.Length < 1 || s.Length > 32)
                throw new ArgumentException("Input lenght should be between 1 and 32", nameof(s.Length));

            if (s.Any(val => val < '0' || val > '9'))
                throw new ArgumentException("Each digit must between 0 and 9", nameof(s));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                Result.separateNumbers(s);
            }

            Console.ReadLine();
        }
    }
}