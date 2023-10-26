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