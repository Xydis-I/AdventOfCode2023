namespace AdventOfCode2023.Day02
{
    internal class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day02_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var games = new List<List<List<string>>>();
                foreach (var line in lines)
                {
                    var rounds = line[8..].Split("; ").ToList();
                    var game = new List<List<string>>();
                    foreach (var round in rounds)
                        game.Add(round.Split(", ").ToList());
                    games.Add(game);
                }


                var total = new List<int>();

                for (int i = 0; i < games.Count; i++)
                {
                    var maxRed = 0;
                    var maxGreen = 0;
                    var maxBlue = 0;
                    foreach (var round in games[i])
                        foreach (var handful in round)
                        {
                            if (handful.Trim().Split(' ')[1] == "red" && int.Parse(handful.Trim().Split(' ')[0]) > maxRed)
                                maxRed = int.Parse(handful.Trim().Split(' ')[0]);
                            if (handful.Trim().Split(' ')[1] == "green" && int.Parse(handful.Trim().Split(' ')[0]) > maxGreen)
                                maxGreen = int.Parse(handful.Trim().Split(' ')[0]);
                            if (handful.Trim().Split(' ')[1] == "blue" && int.Parse(handful.Trim().Split(' ')[0]) > maxBlue)
                                maxBlue = int.Parse(handful.Trim().Split(' ')[0]);
                        }
                    total.Add(maxRed * maxGreen * maxBlue);
                }
                Console.WriteLine(total.Sum());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}