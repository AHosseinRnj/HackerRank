namespace ClimbingTheLeaderboard
{
    class Result
    {

        /*
         * Complete the 'climbingLeaderboard' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY ranked
         *  2. INTEGER_ARRAY player
         */

        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            return new List<int>();
        }

        private static void Validate(List<int> ranked, List<int> player)
        {
            var n = ranked.Count;
            if (n < 1 || n > Math.Pow(2, 10 ^ 5))
                throw new ArgumentException("", nameof(n));

            var m = player.Count;
            if (m < 1 || m > Math.Pow(2, 10 ^ 5))
                throw new ArgumentException("", nameof(m));

            if (ranked.Any(val => val < 0 || val > Math.Pow(10, 9)))
                throw new ArgumentException("", nameof(ranked));

            if (player.Any(val => val < 0 || val > Math.Pow(10, 9)))
                throw new ArgumentException("", nameof(player));
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

            int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

            List<int> result = Result.climbingLeaderboard(ranked, player);

            Console.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}