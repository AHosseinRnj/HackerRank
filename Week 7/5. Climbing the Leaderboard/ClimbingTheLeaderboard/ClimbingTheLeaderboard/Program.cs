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
            //Validate(ranked, player);

            var result = new List<int>();
            ranked = ranked.Distinct().ToList();
            int n = ranked.Count;

            foreach (var score in player)
            {
                while (n > 0 && score >= ranked[n - 1])
                    n--;

                result.Add(n + 1);
            }

            return result;
        }

        private static void Validate(List<int> ranked, List<int> player)
        {
            var n = ranked.Count;
            if (n < 1 || n > Math.Pow(2, 10 ^ 5))
                throw new ArgumentException("Number of players on the leaderboard must be between 2 and 10^5", nameof(n));

            var m = player.Count;
            if (m < 1 || m > Math.Pow(2, 10 ^ 5))
                throw new ArgumentException("Number of games the player plays must be between 2 and 10^5", nameof(m));

            if (ranked.Any(val => val < 0 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Leaderboard scores must be between 0 and 10^9", nameof(ranked));

            if (player.Any(val => val < 0 || val > Math.Pow(10, 9)))
                throw new ArgumentException("Game scores must be between 0 and 10^9", nameof(player));
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