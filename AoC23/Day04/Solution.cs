namespace AoC23.Day04;

public static class Solution
{
    public static int GetResult_Part1(params string[] lines)
        => lines.Select(line => new Scratchcard(line)).Sum(card => card.CardPoints);

    public static int GetResult_Part2(params string[] lines)
        => new ScratchcardGame(lines.Select(l => new ScratchcardV2(l)).ToList()).WinningCardsCount;
}