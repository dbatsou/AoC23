namespace AoC23.Day06;

public static class Solution
{
    public static int GetResult_Part1(params string[] input) =>
        BoatRace.CalculateWinningWaysProduct(BoatRace.ExtractRaces(input));
}