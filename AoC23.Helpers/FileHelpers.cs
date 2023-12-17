namespace AoC23.Helpers;

public static class FileHelpers
{
    public static string[] GetLinesForInput(int day)
    {
        var current = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName;
        var input = Path.Combine(current,"AoC23", "input", $"{day}.txt") ;
        return File.ReadAllLines(input);
    }

}