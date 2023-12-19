using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace AoC23.Day08;

public class PuzzleMap
{
    public const string Start = "AAA";
    public const string End = "ZZZ";
    public BigInteger StepsToEnd => CalculateStepsToEnd();

    public string StartingInstructions { get; }
    public readonly Dictionary<string, PuzzleNode> NetworkNodes;

    public PuzzleMap(string[] input)
    {
        NetworkNodes = new Dictionary<string, PuzzleNode>();
        StartingInstructions= input.First().Trim();

        var map = input.Skip(2);
        foreach (var line in map)
        {
            var currentLine = line.Replace("(", "").Replace(")", "");
            var key = currentLine.Split("=")[0].Trim();
            var left = currentLine.Split("=")[1].Split(",")[0].Trim();
            var right = currentLine.Split("=")[1].Split(",")[1].Trim();

            var n = new PuzzleNode(left, right);
            NetworkNodes.Add(key, n);
        }

    }

    protected virtual BigInteger CalculateStepsToEnd()
    {
        
        BigInteger stepTaken = 0;
        var current = Start;
        var availableInstructions = StartingInstructions;
        bool takeRight = default;
        
        while (current != End)
        {
            var currentNode = NetworkNodes[current];
            if (availableInstructions.Length > 0)
            {
                takeRight = availableInstructions.First() == 'R';
                availableInstructions = availableInstructions.Substring(1);

            }
            else
            {
                availableInstructions = StartingInstructions;
                continue;
            }

            current = takeRight ? currentNode._right : currentNode._left;
            stepTaken++; //increase step counter

        }

        return stepTaken;
    }

}