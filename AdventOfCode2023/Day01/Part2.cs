namespace AdventOfCode2023.Day01
{
    internal static class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day01_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var numStrings = new Dictionary<string, int>()
                {
                    {"one", 1},
                    {"two", 2},
                    {"three", 3},
                    {"four", 4},
                    {"five", 5},
                    {"six", 6},
                    {"seven", 7},
                    {"eight", 8},
                    {"nine", 9}
                };

                var numbers = new List<int>();
                foreach (var line in lines)
                {
                    var dict = new SortedDictionary<int, string>();
                    foreach (var numString in numStrings.Keys)
                    {
                        if (!line.Contains(numString)) continue;
                        var first = line.IndexOf(numString);
                        var last = line.LastIndexOf(numString);
                        if (first == last)
                            dict.Add(first, numStrings[numString].ToString());
                        else
                        {
                            dict.Add(first, numStrings[numString].ToString());
                            dict.Add(last, numStrings[numString].ToString());
                        }
                    }
                    for (var i = 0; i < line.Length; i++)
                        if (int.TryParse(line[i].ToString(), out _))
                            dict.Add(i, line[i].ToString());
                    numbers.Add(int.Parse(dict[dict.Keys.ToList()[0]] + dict[dict.Keys.ToList()[^1]]));
                }
                Console.WriteLine(numbers.Sum());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
