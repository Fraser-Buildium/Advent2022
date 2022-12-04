namespace Advent2022;

public static class Day4
{
    public static void Execute()
    {
        var lines = File.ReadAllLines("input4.txt");
        var sum = 0;
        foreach (var line in lines)
        {
            var (start1, end1, start2, end2) = Parse(line);
            if (start1 <= start2 && end2 <= end1)
            {
                Console.Out.WriteLine($"Range 2 fully contained: {line}");
                sum++;
            }
            else if (start2 <= start1 && end1 <= end2)
            {
                Console.Out.WriteLine($"Range 1 fully contained: {line}");
                sum++;
            }
        }
        Console.Out.WriteLine($"Total 1: {sum}");
    }
    
    public static void Execute2()
    {
        var lines = File.ReadAllLines("input4.txt");
        var sum = 0;
        foreach (var line in lines)
        {
            var (start1, end1, start2, end2) = Parse(line);
            var range1Numbers = Enumerable.Range(start1, end1 - start1 + 1).ToHashSet();
            var range2Numbers = Enumerable.Range(start2, end2 - start2 + 1).ToHashSet();
            var intersection = range1Numbers
                .Intersect(range2Numbers)
                .ToList();

            if (!intersection.Any())
            {
                continue;
            }
            
            var intersectionStart = intersection.First();
            var intersectionEnd = intersection.Last();
            Console.Out.WriteLine($"{line} intersection {intersectionStart}-{intersectionEnd}");
            sum++;
        }
        
        Console.Out.WriteLine($"Total 2: {sum}");
    }

    private static (int start1, int end1, int start2, int end2) Parse(string line)
    {
        var parsedArray = line.Split(",")
            .SelectMany(pair => pair.Split("-"))
            .Select(int.Parse)
            .ToArray();
        return (parsedArray[0], parsedArray[1], parsedArray[2], parsedArray[3]);
    }
}