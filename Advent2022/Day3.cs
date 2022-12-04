using MoreLinq;

namespace Advent2022;

public class Day3
{
    public static int Execute()
    {
        var lines = File.ReadAllLines("input3.txt");
        var sum = 0;

        foreach (var line in lines)
        {
            var compartment1 = new HashSet<char>(line[..(line.Length/2)]);
            var compartment2 = new HashSet<char>(line[(line.Length/2)..]);
            var items = compartment1
                .Intersect(compartment2)
                .ToList();

            if (items.Any())
            {
                Console.Out.WriteLine($"{line[..(line.Length / 2)]} {line[(line.Length / 2)..]}:");
                foreach (var item in items)
                {
                    var priority = Prioritize(item);
                    Console.Out.WriteLine($"  {item}: {priority} ");
                    sum += priority;
                }
            }
        }
        
        Console.Out.WriteLine($"Total sum: {sum}");
        return sum;
    }

    public static int Execute2()
    {
        var lines = File.ReadAllLines("input3.txt");
        var sum = 0;
        
        foreach (var elfGroup in lines.Batch(3).Select(e => e.ToArray()))
        {
            var rucksack1 = new HashSet<char>(elfGroup[0]);
            var rucksack2 = new HashSet<char>(elfGroup[1]);
            var rucksack3 = new HashSet<char>(elfGroup[2]);

            var badge = rucksack1
                .Intersect(rucksack2)
                .Intersect(rucksack3)
                .Single();
            var priority = Prioritize(badge);
            Console.Out.WriteLine($"{badge} - {priority}");
            sum += priority;
        }
        
        Console.WriteLine($"Total sum: {sum}");
        return sum;
    }

    private static int Prioritize(char item)
    {
        return char.IsLower(item)
            ? item - 'a' + 1
            : item - 'A' + 27;
    }
}