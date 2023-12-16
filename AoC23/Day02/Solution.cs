namespace AoC23.Day02;

public static class Solution
{
    public static int GetResult_Part1(params string[] lines) 
        => lines.Select(game => new Game(game)).Where(g => g.GameIsPossible).Sum(g => g.ReturnValue);
    public static int GetResult_Part2(params string[] lines) 
        => lines.Select(game => new Game(game)).Sum(g => g.FewestCubesPower);
}