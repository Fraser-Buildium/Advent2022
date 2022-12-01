namespace Advent2022;

public class Day1
{
    public static void Execute()
    {
        var lines = File.ReadAllLines("input1.txt");
        var elfCalories = new SortedSet<int>();
        var currentSum = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                elfCalories.Add(currentSum);
                currentSum = 0;
                continue;
            }

            if (int.TryParse(line, out var currentCalories))
            {
                currentSum += currentCalories;
            }
        }

        // Part 1
        Console.Out.WriteLine(elfCalories.Last());

        // Part 2
        Console.Out.WriteLine(elfCalories.TakeLast(3).Sum());
    }
}