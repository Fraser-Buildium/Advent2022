namespace Advent2022;

public class Day2
{
    private const int Rock = 1;
    private const int Paper = 2;
    private const int Scissors = 3;
    
    private const int Lose = 0;
    private const int Draw = 3;
    private const int Win = 6;
    
    public static void Execute()
    {
        var score1 = 0;
        var score2 = 0;
        var lines = File.ReadAllLines("input2.txt");
        foreach (var line in lines)
        {
            score1 += Score1(line);
            score2 += Score2(line);
        }
        Console.Out.WriteLine(score1);
        Console.Out.WriteLine(score2);
    }

    private static int Score1(string line)
    {
        return line switch
        {
            "A X" => // Rock, Rock
                Rock + Draw,
            "A Y" => // Rock, Paper
                Paper + Win,
            "A Z" => // Rock, Scissors
                Scissors + Lose,
            "B X" => // Paper, Rock
                Rock + Lose,
            "B Y" => // Paper, Paper
                Paper + Draw,
            "B Z" => // Paper, Scissors
                Scissors + Win,
            "C X" => // Scissors, Rock
                Rock + Win,
            "C Y" => // Scissors, Paper
                Paper + Lose,
            "C Z" => // Scissors, Scissors
                Scissors + Draw,
            _ => throw new Exception($"Unmatched: {line}")
        };
    }

    private static int Score2(string line)
    {
        return line switch
        {
            "A X" => // Rock, Lose
                Scissors + Lose,
            "A Y" => // Rock, Draw
                Rock + Draw,
            "A Z" => // Rock, Win
                Paper + Win,
            "B X" => // Paper, Lose
                Rock + Lose,
            "B Y" => // Paper, Draw
                Paper + Draw,
            "B Z" => // Paper, Win
                Scissors + Win,
            "C X" => // Scissors, Lose
                Paper + Lose,
            "C Y" => // Scissors, Draw
                Scissors + Draw,
            "C Z" => // Scissors, Win
                Rock + Win,
            _ => throw new Exception($"Unmatched: {line}")
        };
    }
}