using AoC23.Day06;
using AoC23.Helpers;

namespace AoC23.Tests.Day;

public class Day06
{
    [Fact]
    public void Extract_races_from_file()
    {
        var input = FileHelpers.GetLinesForInput(6, true);
        var lst = BoatRace.ExtractRaces(input);
        
        Assert.Equal(3,lst.Count());
    }
    
    
    [Fact]
    public void Solve_example()
    {
        var input = FileHelpers.GetLinesForInput(6, true);
        var lst = BoatRace.ExtractRaces(input);

        var boatRaces = lst.ToList();
        var first = boatRaces.First();
        var second = boatRaces.Skip(1).First();
        var third = boatRaces.Skip(2).First();
        
        Assert.Equal(4,first.WaysToWin);
        Assert.Equal(8,second.WaysToWin);
        Assert.Equal(9,third.WaysToWin);
    }
    
    
    [Fact]
    public void ProductOfPossibleWays_For_example()
    {
        var input = FileHelpers.GetLinesForInput(6, true);
        var lst = BoatRace.ExtractRaces(input);

        Assert.Equal(288,BoatRace.CalculateWinningWaysProduct(lst));
    }
    
    [Fact]
    public void ProductOfPossibleWays_For_example_1()
    {
        var input = FileHelpers.GetLinesForInput(6);
        var lst = BoatRace.ExtractRaces(input);

        Assert.Equal(449550,BoatRace.CalculateWinningWaysProduct(lst));
    }
    
    [Fact]
    public static void Solution_Part1()
    {
        var input = FileHelpers.GetLinesForInput(6);
        var result = Solution.GetResult_Part1(input);
        Assert.Equal(449550,result);
    }
    
}