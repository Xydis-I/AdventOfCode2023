namespace AdventOfCode2023.Day01
{
    internal static class Part1
    {
        private const string FileLocation = @"..\..\..\Inputs\Day01_Input.txt";

        public static void Solution()
        {
            try
            {
                using var input = new StreamReader(FileLocation);
                var lines = input.ReadToEnd().Split("\r\n");

                var numbers = new List<int>();
                foreach (var line in lines)
                {
                    var chars = new List<string>();
                    foreach (var letter in line)
                        if (int.TryParse(letter.ToString(), out _))
                            chars.Add(letter.ToString());
                    numbers.Add(int.Parse(chars[0] + chars[^1]));
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