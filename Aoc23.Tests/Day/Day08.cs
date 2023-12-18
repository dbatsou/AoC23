using AoC23.Day08;
using AoC23.Helpers;

namespace AoC23.Tests.Day;

public class Day08
{
    private const int Day = 8;
    private PuzzleMap _map;
    private string[] _example1Input = FileHelpers.GetLinesForInput(Day, true);
    private string[] _example2Input = FileHelpers.GetLinesForInput(Day, true, 2);
    private string[] _input = FileHelpers.GetLinesForInput(Day);

    #region examples / basic

    [Fact]
    public void Parse_file_add_nodes()
    {

        _map = new PuzzleMap(_example1Input);

        Assert.Equal(7, _map.NetworkNodes.Count);
        Assert.Equal("AAA", PuzzleMap.Start);
        Assert.Equal("ZZZ", PuzzleMap.End);
        Assert.Equal("RL", _map.StartingInstructions);
    }

    [Fact]
    public void Part1_steps_to_reach_end_example()
    {
        _map = new PuzzleMap(_example1Input);

        Assert.Equal(2, _map.StepsToEnd);
    }


    [Fact]
    public void Solution_Part1_example1()
    {
        var result = Solution.GetResult_Part1(_example2Input);

        Assert.Equal(6, result);
    }

    [Fact]
    public void Solution_Part1_example2()
    {
        var result = Solution.GetResult_Part1(_example2Input);

        Assert.Equal(6, result);
    }

    #endregion

    [Fact]
    public void Solution_Part1()
    {
        var result = Solution.GetResult_Part1(_input);
        Assert.Equal(15517, result);
    }
}