namespace AoC23.Day04;

public class Scratchcard
{
    protected readonly string Input;
    protected readonly IEnumerable<int> WinningNumbers;
    protected readonly IEnumerable<int> PlayerNumbers;
    public virtual int CardPoints => (int)Math.Pow(2, (PlayerNumbers.Intersect(WinningNumbers).Count() - 1));
    public virtual int GameId => int.Parse(Input.Split(":")[0].Split(" ")[1]);

    public Scratchcard(string input)
    {
        Input = input;
        var numberList = input.Split(":")[1];

        WinningNumbers = GetListAsList(numberList, 0);
        PlayerNumbers = GetListAsList(numberList, 1);
    }

    private static IEnumerable<int> GetListAsList(string numberList, int firstList)
    {
        return numberList.Split("|")[firstList].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).Select(int.Parse);
    }

    public override string ToString() => Input;
}