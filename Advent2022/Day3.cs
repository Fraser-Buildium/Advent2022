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
            var compartment1 = new HashSet<char>();

            var compartment1String = line.Substring(0, line.Length/2);
            var compartment1Contents =compartment1String.Distinct();
            foreach (var item in compartment1Contents)
            {
                compartment1.Add(item);
            }

            var compartment2String = line.Substring(line.Length/2, line.Length/2);
            var compartment2Contents = compartment2String.Distinct();
            foreach (var item in compartment2Contents)
            {
                if (compartment1.Contains(item))
                {
                    var priority = Prioritize(item);
                    Console.Out.Write($"{compartment1String} {compartment2String} - {item}: {priority}");
                    sum += priority;
                }
            }

            Console.Out.WriteLine();
        }
        
        Console.WriteLine($"Total sum: {sum}");
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

            var badge = rucksack1.Intersect(rucksack2).Intersect(rucksack3).Single();
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