namespace SmartNumber2
{
    public class Program
    {
        // Debug Problem.
    }

    class Result
    {
        public static bool isSmartNumber(int num)
        {
            int val = (int)Math.Sqrt(num);
            if (num % val == 0 && num / val == val)
                return true;
            return false;
        }
    }
}