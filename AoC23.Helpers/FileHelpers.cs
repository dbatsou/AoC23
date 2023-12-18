namespace AoC23.Helpers;

public static class FileHelpers
{
    public static string[] GetLinesForInput(int day, bool exampleFile = false, int exampleId=0)
    {
        var current = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName;
        var input = Path.Combine(current,"AoC23", "input", $"{day}{(exampleFile ? "e" : "")}{(exampleId!=0 ? $"{exampleId}" : "")}.txt") ;
        return File.ReadAllLines(input);
    }

}