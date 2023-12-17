namespace AoC23.Helpers;

public static class FileHelpers
{
    public static string[] GetLinesForInput(int day, bool exampleFile = false)
    {
        var current = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName;
        var input = Path.Combine(current,"AoC23", "input", $"{day}{(exampleFile ? "e" : "")}.txt") ;
        return File.ReadAllLines(input);
    }

}