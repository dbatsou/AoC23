using AoC23.Day06;
using AoC23.Helpers;

namespace AoC23.Tests.Day;

public class Day06
{
    private string[] _exampleInput;
    private string[] _input;

    public Day06()
    {
        _input = FileHelpers.GetPartOneInput(6);
        _exampleInput = FileHelpers.GetPartOneInput(6, true);
        
    }
    
    [Fact]
    public void Extract_races_from_file()
    {
        var lst = BoatRace.ExtractRaces(_exampleInput);
        
        Assert.Equal(3,lst.Count());
    }
    
    
    [Fact]
    public void Solve_example()
    {
        var lst = BoatRace.ExtractRaces(_exampleInput);

        var boatRaces = lst.ToList();
        var first = boatRaces.First();
        var second = boatRaces.Skip(1).First();
        var third = boatRaces.Skip(2).First();
        
        Assert.Equal(4,first.WaysToWin);
        Assert.Equal(8,second.WaysToWin);
        Assert.Equal(9,third.WaysToWin);
        Assert.Equal(288,BoatRace.CalculateWinningWaysProduct(lst));
    }
    
    [Fact]
    public void ProductOfPossibleWays_For_example_1()
    {
        var lst = BoatRace.ExtractRaces(_input);

        Assert.Equal(449550,BoatRace.CalculateWinningWaysProduct(lst));
    }

    [Fact]
    public void Solution_Part1()
    {
        var result = Solution.GetResult_Part1(_input);
        Assert.Equal(449550, result);

    }

    [Fact]
    public void Solution_Part2()
    {
        var result = Solution.GetResult_Part2(_input);
        Assert.Equal(28360140,result);
    }

    [Fact]
    public void Parses_duration_and_record_according_to_example()
    {
        var race = BoatRace.ExtractRace(_exampleInput);
        
        Assert.Equal(71530,race.Duration);
        Assert.Equal(940200,race.Record);
    }
    
    [Fact]
    public void Part2_example()
    {
        FileHelpers.GetPartOneInput(6,true);

        var race = BoatRace.ExtractRace(_exampleInput);
        
        Assert.Equal(71503,race.WaysToWin);
    }
    
    [Fact]
    public void Part2()
    {
        var race = BoatRace.ExtractRace(_input);

        Assert.Equal(28360140,race.WaysToWin);
    }
}