namespace Advent2022;

public class Day2
{
    public const int Rock = 1;
    public const int Paper = 2;
    public const int Scissors = 3;
    public const int Lose = 0;
    public const int Draw = 3;
    public const int Win = 6;
    public static void Execute()
    {
        int score1 = 0;
        int score2 = 0;
        var lines = File.ReadAllLines("input2.txt");
        foreach (var line in lines)
        {
            switch (line)
            {
                case "A X": // Rock, Rock
                    score1 += Rock + Draw;
                    break;
                
                case "A Y": // Rock, Paper
                    score1 += Paper + Win;
                    break;
                
                case "A Z": // Rock, Scissors
                    score1 += Scissors + Lose;
                    break;
                
                case "B X": // Paper, Rock
                    score1 += Rock + Lose;
                    break;
                
                case "B Y": // Paper, Paper
                    score1 += Paper + Draw;
                    break;
                
                case "B Z": // Paper, Scissors
                    score1 += Scissors + Win;
                    break;
                
                case "C X": // Scissors, Rock
                    score1 += Rock + Win;
                    break;
                
                case "C Y": // Scissors, Paper
                    score1 += Paper + Lose;
                    break;
                
                case "C Z": // Scissors, Scissors
                    score1 += Scissors + Draw;
                    break;
                
                default:
                    Console.Out.WriteLine($"Unmatched: {line}");
                    break;
            }
            
            switch (line)
            {
                case "A X": // Rock, Lose
                    score2 += Scissors + Lose;
                    break;
                
                case "A Y": // Rock, Draw
                    score2 += Rock + Draw;
                    break;
                
                case "A Z": // Rock, Win
                    score2 += Paper + Win;
                    break;
                
                case "B X": // Paper, Lose
                    score2 += Rock + Lose;
                    break;
                
                case "B Y": // Paper, Draw
                    score2 += Paper + Draw;
                    break;
                
                case "B Z": // Paper, Win
                    score2 += Scissors + Win;
                    break;
                
                case "C X": // Scissors, Lose
                    score2 += Paper + Lose;
                    break;
                
                case "C Y": // Scissors, Draw
                    score2 += Scissors + Draw;
                    break;
                
                case "C Z": // Scissors, Win
                    score2 += Rock + Win;
                    break;
                
                default:
                    Console.Out.WriteLine($"Unmatched: {line}");
                    break;
            }
        }
        Console.Out.WriteLine(score1);
        Console.Out.WriteLine(score2);
    }
}