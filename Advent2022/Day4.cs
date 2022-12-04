namespace Advent2022;

public static class Day4
{
    public static void Execute()
    {
        var lines = File.ReadAllLines("input4.txt");
        var sum = 0;
        foreach (var line in lines)
        {
            var pair = line.Split(",");
            var range1 = pair[0].Split("-");
            var range2 = pair[1].Split("-");
            var start1 = int.Parse(range1[0]);
            var end1 = int.Parse(range1[1]);
            var start2 = int.Parse(range2[0]);
            var end2 = int.Parse(range2[1]);
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
        Console.Out.WriteLine($"Total 2: {sum}");
    }
    
    public static void Execute2()
    {
        var lines = File.ReadAllLines("input4.txt");
        var sum = 0;
        foreach (var line in lines)
        {
            var pair = line.Split(",");
            var range1 = pair[0].Split("-");
            var range2 = pair[1].Split("-");
            var start1 = int.Parse(range1[0]);
            var end1 = int.Parse(range1[1]);
            var start2 = int.Parse(range2[0]);
            var end2 = int.Parse(range2[1]);
            var range1Numbers = Enumerable.Range(start1, end1 - start1 + 1).ToHashSet();
            var range2Numbers = Enumerable.Range(start2, end2 - start2 + 1).ToHashSet();
            var intersection = range1Numbers.Intersect(range2Numbers).ToList();
            if (intersection.Any())
            {
                Console.Out.WriteLine($"{line} intersection {intersection.First()}-{intersection.Last()}");
                sum++;
            }
        }
        
        Console.Out.WriteLine($"Total 2: {sum}");
    }
}