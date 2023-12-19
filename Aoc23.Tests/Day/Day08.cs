using System.Numerics;
using AoC23.Day08;
using AoC23.Helpers;

namespace AoC23.Tests.Day;

public class Day08
{
    private const int Day = 8;
    private PuzzleMap _map;
    private string[] _example1InputPart1 = FileHelpers.GetPartOneInput(Day, true);
    private string[] _example2InputPart1 = FileHelpers.GetPartOneInput(Day, true, 2);
    private string[] _example1InputPart2 = FileHelpers.GetPartTwoInput(Day, true);
    private string[] _input = FileHelpers.GetPartOneInput(Day);

    #region examples / basic

    [Fact]
    public void Parse_file_add_nodes()
    {

        _map = new PuzzleMap(_example1InputPart1);

        Assert.Equal(7, _map.NetworkNodes.Count);
        Assert.Equal("AAA", PuzzleMap.Start);
        Assert.Equal("ZZZ", PuzzleMap.End);
        Assert.Equal("RL", _map.StartingInstructions);
    }

    [Fact]
    public void Part1_steps_to_reach_end_example()
    {
        _map = new PuzzleMap(_example1InputPart1);

        Assert.Equal(2, _map.StepsToEnd);
    }


    [Fact]
    public void Solution_Part1_example1()
    {
        var result = Solution.GetResult_Part1(_example2InputPart1);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Solution_Part1_example2()
    {
        var result = Solution.GetResult_Part1(_example2InputPart1);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Part2_steps_to_reach_end_example1()
    {
        _map = new AdvancedPuzzleMap(_example1InputPart2);

        Assert.Equal(6, _map.StepsToEnd);
    }

    [Fact(Skip = "x")]
    public void Part2_steps_to_reach_end()
    {
        _map = new AdvancedPuzzleMap(_input);

        Assert.Equal(6, _map.StepsToEnd);
    }

    #endregion

}

public class AdvancedPuzzleMap : PuzzleMap
{
    public AdvancedPuzzleMap(string[] example1Input) : base(example1Input)
    {

    }

    protected override BigInteger CalculateStepsToEnd()
    {
        var currentNodes = GetNodesForCharacter("A").Select(x => x.Key).ToList();
        var endNodes = GetNodesForCharacter("Z").Select(x=>x.Key).ToList();
        
        var updated = new List<string>();
        bool winning = default;
        var availableInstructions = StartingInstructions;
        BigInteger stepTaken = default;

        while (!winning)
        {
            bool takeRight = default;
            if (availableInstructions.Length > 0)
            {
                takeRight = availableInstructions.First() == 'R';
                availableInstructions = availableInstructions[1..];
            }
            else
            {
                availableInstructions = StartingInstructions;
                continue;
            }

            updated = new();
            for (var i = 0; i < currentNodes.Count; i++)
            {
                var current = NetworkNodes[currentNodes[i]];
                string nodeToAdd;

                nodeToAdd = takeRight ? current._right : current._left;
                updated.Add(nodeToAdd);
            }
            stepTaken++; 

            currentNodes = updated;
            var currentNodesEndingInZ = currentNodes.Count(x => x.EndsWith("Z"));

            winning = currentNodesEndingInZ == endNodes.Count;
        }

        return stepTaken;
    }

    private IEnumerable<KeyValuePair<string,PuzzleNode>> GetNodesForCharacter(string endingCharacter)
    {
        return NetworkNodes.Where(x => x.Key.EndsWith(endingCharacter));
    }
}