namespace AoC23.Day04;

public class Scratchcard
{
    private readonly IEnumerable<int> _winningNumbers;
    private readonly IEnumerable<int> _playerNumbers;
    public int CardPoints => (int)Math.Pow(2, (_playerNumbers.Intersect(_winningNumbers).Count() - 1));

    public Scratchcard(string input)
    {
        var numberList = input.Split(":")[1];

        _winningNumbers = GetListAsList(numberList, 0);
        _playerNumbers = GetListAsList(numberList, 1);
    }

    private static IEnumerable<int> GetListAsList(string numberList, int firstList)
    {
        return numberList.Split("|")[firstList].Split(" ").Where(x=> !string.IsNullOrEmpty(x)).Select(int.Parse);
    }
}