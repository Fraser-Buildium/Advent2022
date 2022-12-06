namespace Advent2022;

public class Day6
{
    public static void Execute(int uniqueCount)
    {
        using var reader = new StreamReader("input6.txt");
        
        var queue = new Queue<char>();
        var index = 1;
        while (!reader.EndOfStream)
        {
            var currentCharacter = (char) reader.Read();
            queue.Enqueue(currentCharacter);
            if (queue.Count > uniqueCount)
            {
                queue.Dequeue();
            }
            else
            {
                continue;
            }

            var distinctQueue = new HashSet<char>(queue);
            if (distinctQueue.Count == uniqueCount)
            {
                Console.WriteLine($"Start with {uniqueCount} unique characters: {index}");
                break;
            }

            index++;
        }
    }
}