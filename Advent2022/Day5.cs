using System.Collections;
using System.Text.RegularExpressions;

namespace Advent2022;

public class Day5
{
    public static void Execute()
    {
        var lines = File.ReadAllLines("input5.txt");
        var sum = 0;
        
        // [V]     [C]     [M]
        // [V]     [J]     [N]     [H]     [V]
        // [R] [F] [N]     [W]     [Z]     [N]
        // [H] [R] [D]     [Q] [M] [L]     [B]
        // [B] [C] [H] [V] [R] [C] [G]     [R]
        // [G] [G] [F] [S] [D] [H] [B] [R] [S]
        // [D] [N] [S] [D] [H] [G] [J] [J] [G]
        // [W] [J] [L] [J] [S] [P] [F] [S] [L]
        // 1   2   3   4   5   6   7   8   9 

        var stacks = new Dictionary<int, Stack<char>>
        {
            {1, new Stack<char>("WDGBHRV")},
            {2, new Stack<char>("JNGCRF")},
            {3, new Stack<char>("LSFHDNJ")},
            {4, new Stack<char>("JDSV")},
            {5, new Stack<char>("SHDRQWNV")},
            {6, new Stack<char>("PGHCM")},
            {7, new Stack<char>("FJBGLZHC")},
            {8, new Stack<char>("SJR")},
            {9, new Stack<char>("LGSRBNVM")}
        };

        var movePattern = new Regex("move (?<stack>[0-9]+) from (?<from>[0-9]+) to (?<to>[0-9]+)");
        foreach (var line in lines)
        {
            var matches = movePattern.Matches(line);
            if (!matches.Any())
            {
                Console.WriteLine(line);
                continue;
            }
            
            var match = matches.Single();
            var quantity = int.Parse(match.Groups["stack"].ToString());
            var from = int.Parse(match.Groups["from"].ToString());
            var to = int.Parse(match.Groups["to"].ToString());
            
            for (var i = 0; i < quantity; i++)
            {
                var item = stacks[from].Pop();
                stacks[to].Push(item);
            }
        }
        
        PrintStacks(stacks);

        Console.Write("Answer 1: ");
        foreach (var stack in stacks)
        {
            Console.Write(stack.Value.Peek());
        }
        Console.WriteLine();
    }
    
    public static void Execute2()
    {
        var lines = File.ReadAllLines("input5.txt");
        
        // [V]     [C]     [M]
        // [V]     [J]     [N]     [H]     [V]
        // [R] [F] [N]     [W]     [Z]     [N]
        // [H] [R] [D]     [Q] [M] [L]     [B]
        // [B] [C] [H] [V] [R] [C] [G]     [R]
        // [G] [G] [F] [S] [D] [H] [B] [R] [S]
        // [D] [N] [S] [D] [H] [G] [J] [J] [G]
        // [W] [J] [L] [J] [S] [P] [F] [S] [L]
        // 1   2   3   4   5   6   7   8   9 

        var stacks = new Dictionary<int, Stack<char>>
        {
            {1, new Stack<char>("WDGBHRV")},
            {2, new Stack<char>("JNGCRF")},
            {3, new Stack<char>("LSFHDNJ")},
            {4, new Stack<char>("JDSV")},
            {5, new Stack<char>("SHDRQWNV")},
            {6, new Stack<char>("PGHCM")},
            {7, new Stack<char>("FJBGLZHC")},
            {8, new Stack<char>("SJR")},
            {9, new Stack<char>("LGSRBNVM")}
        };

        var movePattern = new Regex("move (?<stack>[0-9]+) from (?<from>[0-9]+) to (?<to>[0-9]+)");
        foreach (var line in lines)
        {
            var matches = movePattern.Matches(line);
            if (!matches.Any())
            {
                Console.WriteLine(line);
                continue;
            }
            
            var match = movePattern.Matches(line).Single();
            var quantity = int.Parse(match.Groups["stack"].ToString());
            var from = int.Parse(match.Groups["from"].ToString());
            var to = int.Parse(match.Groups["to"].ToString());
            
            var list = new List<char>();
            for (var i = 0; i < quantity; i++)
            {
                var item = stacks[from].Pop();
                list.Add(item);
            }
            
            foreach (var item in list.AsEnumerable().Reverse())
            {
                stacks[to].Push(item);
            }
        }

        PrintStacks(stacks);
        Console.Write("Answer 2: ");
        foreach (var stack in stacks)
        {
            Console.Write(stack.Value.Peek());
        }
        Console.WriteLine();
    }

    private static void PrintStacks(Dictionary<int, Stack<char>> stacks)
    {
        foreach (var stack in stacks)
        {
            Console.WriteLine($"{stack.Key}: [{string.Join("], [", stack.Value)}]");
        }
    }
}