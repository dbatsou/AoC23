using AoC23.Day02;
using AoC23.Helpers;
using Solution = AoC23.Day02.Solution;

namespace AoC23.Tests.Day;

public static class Day02
{
    public record TestCaseSimple(string input, bool expectedGamePossible, int expectedReturnValue);
    private static readonly List<TestCaseSimple> _casesSimple = new()
    {
        new("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",  true, 1),
        new("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",  true, 2),
        new("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",  true, 5),
        new("Game 79: 3 green, 1 blue, 2 red; 8 green, 1 blue, 2 red; 2 blue, 1 red, 11 green",true, 79),
        new("Game 1: 7 blue, 4 red, 11 green; 2 red, 2 blue, 7 green; 2 red, 13 blue, 8 green; 18 blue, 7 green, 5 red", false, 0),
    };

    public static IEnumerable<object[]> simpleCaseSource => new List<object[]>
    {
        new object[] { _casesSimple, 87 },
    };

    [Theory]
    [MemberData(nameof(simpleCaseSource))]
    public static void Validate_Part1(List<TestCaseSimple> cases, int expected)
    {
        var sumOfIdsOfPossibleGames = 0;

        Assert.All(cases, c =>
        {
            var game = new Game(c.input);
            sumOfIdsOfPossibleGames += game.ReturnValue;

            Assert.Equal(c.expectedGamePossible, game.GameIsPossible);
            Assert.Equal(c.expectedReturnValue, game.ReturnValue);
        });
        
        Assert.Equal(expected,sumOfIdsOfPossibleGames);

    }


    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",48)] //4 red, 2 green, 6 blue, 48 expected power
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",12)] 
    public static void Part2(string input,int expectedPower)
    {
        Game g = new Game(input);

        Assert.Equal(expectedPower,g.FewestCubesPower);
    }

    [Fact]
    public static void Solution_Part1()
    {
        var input = FileHelpers.GetPartOneInput(2);
        var result = Solution.GetResult_Part1(input);
        Assert.Equal(2476,result);
    }
    
    [Fact]
    public static void Solution_Part2()
    {
        var input = FileHelpers.GetPartOneInput(2);
        var result = Solution.GetResult_Part2(input);
        Assert.Equal(54911,result);
    }

}
