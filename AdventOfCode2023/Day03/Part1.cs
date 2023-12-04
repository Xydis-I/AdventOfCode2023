using System.Text;

namespace AdventOfCode2023.Day03
{
    internal class Part1
    {
        private const string FileLocation = @"..\..\..\Inputs\Day03_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var grid = new string[lines.Length, lines.Length]; //140,140

                for (int i = 0; i < lines.Length; i++)
                    for (int j = 0; j < lines[i].Length; j++)
                        grid[i, j] = lines[i][j].ToString();

                var partNumbers = new List<int>();

                for (int i = 0; i < lines.Length; i++)
                    for (int j = 0; j < lines.Length;)
                    {
                        var number = new StringBuilder();
                        var part = false;
                        if (int.TryParse(grid[i, j], out _))
                        {
                            number.Append(grid[i, j]);

                            part = CheckNeighbor(grid, i, j, part);
                            if (int.TryParse(grid[i, j + 1], out _))
                            {
                                number.Append(grid[i, j + 1]);
                                part = CheckNeighbor(grid, i, j + 1, part);
                                if (int.TryParse(grid[i, j + 2], out _))
                                {
                                    number.Append(grid[i, j + 2]);
                                    part = CheckNeighbor(grid, i, j + 2, part);
                                    j++;
                                }
                                j++;
                            }
                            if (part)
                                partNumbers.Add(int.Parse(number.ToString()));
                        }
                        j++;
                    }
                Console.WriteLine(partNumbers.Sum());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static bool CheckNeighbor(string[,] grid, int x, int y, bool current)
        {
            if (current)
                return true;

            var symbols = new[]
            {
                "*", "/",
                "$", "+",
                "&", "@",
                "#", "%",
                "=", "-"
            };

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    int newX = x + i;
                    int newY = y + j;
                    if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
                        if (symbols.Contains(grid[newX, newY]))
                            return true;
                }
            return false;
        }
    }
}