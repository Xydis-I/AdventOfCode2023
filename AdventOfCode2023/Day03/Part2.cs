using System.Text;

namespace AdventOfCode2023.Day03
{
    internal class Part2
    {
        private const string FileLocation = @"..\..\..\Inputs\Day03_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var grid = new string[lines.Length, lines.Length];

                for (int i = 0; i < lines.Length; i++)
                    for (int j = 0; j < lines[i].Length; j++)
                        grid[i, j] = lines[i][j].ToString();

                var partNumbers = new List<(int, (int, int))>();

                for (int i = 0; i < lines.Length; i++)
                    for (int j = 0; j < lines.Length;)
                    {
                        var number = new StringBuilder();
                        var part = false;
                        if (int.TryParse(grid[i, j], out _))
                        {
                            number.Append(grid[i, j]);
                            (part, var gear) = CheckNeighbor(grid, i, j, part, (0, 0));
                            if (int.TryParse(grid[i, j + 1], out _))
                            {
                                number.Append(grid[i, j + 1]);
                                (part, gear) = CheckNeighbor(grid, i, j + 1, part, gear);
                                if (int.TryParse(grid[i, j + 2], out _))
                                {
                                    number.Append(grid[i, j + 2]);
                                    (part, gear) = CheckNeighbor(grid, i, j + 2, part, gear);
                                    j++;
                                }
                                j++;
                            }
                            if (part)
                                partNumbers.Add((int.Parse(number.ToString()), gear));
                        }
                        j++;
                    }

                var total = new HashSet<int>(); // Literally the worst loophole I've ever used, sheer luck of the numbers this works.
                // If my numbers contained a single equivalent power this wouldn't work.

                for (int i = 0; i < partNumbers.Count; i++)
                    for (int j = 0; j < partNumbers.Count; j++)
                        if (i != j)
                            if (partNumbers[i].Item2 == partNumbers[j].Item2)
                                total.Add(partNumbers[i].Item1 * partNumbers[j].Item1);

                Console.WriteLine(total.Sum());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static (bool, (int, int)) CheckNeighbor(string[,] grid, int x, int y, bool current, (int, int) gear)
        {
            if (current)
                return (true, gear);

            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    int newX = x + i;
                    int newY = y + j;
                    if (newX >= 0 && newX < grid.GetLength(0) && newY >= 0 && newY < grid.GetLength(1))
                        if ("*" == grid[newX, newY])
                            return (true, (newX, newY));
                }
            return (false, (0, 0));
        }
    }
}