using System.Text.RegularExpressions;

namespace AoC23.Day04;

public class ScratchcardV2 : Scratchcard
{
    public ScratchcardV2(string s) : base(s)
    {
        GameId = int.Parse(Regex.Match(Input, @"\d+").Value);

    }

    public override int GameId { get; }

    public override int CardPoints => PlayerNumbers.Intersect(WinningNumbers).Count();

}