using AoC23.Day06;
using AoC23.Helpers;

namespace AoC23.Tests.Day;

public class Day11
{
    private string[] _exampleInput;
    private string _exampleInput2;
    private string[] _input;

    public Day11()
    {
        // _input = FileHelpers.GetPartOneInput(6);
        _exampleInput = FileHelpers.GetPartOneInput(11, true);
        _exampleInput2 = File.ReadAllText("Input/11e.txt");

    }

    [Fact]
    public void ExpandingGalaxies()
    {
        Galaxy c = new(_exampleInput);

        Assert.Equal(2, c.EmptyHorizontalGalaxies);
        Assert.Equal(2, c.EmptyVerticalGalaxies);
    }



}

internal class Galaxy
{
    internal int EmptyHorizontalGalaxies;
    internal int EmptyVerticalGalaxies;
    private string[] exampleInput;

    public Galaxy(string[] exampleInput)
    {
        this.exampleInput = exampleInput;

        EmptyHorizontalGalaxies = exampleInput.Where(x => x.All(c => c == '.')).Count();
        EmptyVerticalGalaxies = CalculateEmptyVerticalGalaxies();
    }

    int CalculateEmptyVerticalGalaxies()
    {
        for (int i = 0; i < exampleInput.Length; i++)
        {

            bool emptySoFar
        }

        return 0;
    }
}