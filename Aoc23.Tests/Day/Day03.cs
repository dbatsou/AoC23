using AoC23.Day02;
using AoC23.Day03;

namespace Aoc23.Tests.Day;

public static class Day03
{
    private const string exampleCase = 
@"467..114*.
...*......
..35..633.";

// ......#...";
    
    [Theory]
    [InlineData(exampleCase, 581)]
    public static void Part1(string input, int expectedSum)
    {
        var engineSchematic = new EngineSchematic(exampleCase);

        
        Assert.Equal(engineSchematic.Sum, expectedSum);
    }

}