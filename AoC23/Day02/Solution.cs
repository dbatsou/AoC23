namespace AoC23.Day02;

public static class Solution
{
    public static int GetResult_Part1(params string[] lines)
    {
        var gameCount = 0;
        foreach (var game in lines)
        {
            Game g = new Game(game);

            if (g.GameIsPossible)
            {
                Console.WriteLine("Valid game " + g.Id);
                gameCount += g.ReturnValue;
            }
        }
        return gameCount;
    }
}