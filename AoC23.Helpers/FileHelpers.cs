namespace AoC23.Helpers;

public static class FileHelpers
{
    public static string[] GetPartOneInput(int day, bool exampleFile = false, int exampleId=0)
    {
        var current = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName;
        var input = Path.Combine(current,"AoC23", "input", $"{day}{(exampleFile ? "e" : "")}{(exampleId!=0 ? $"{exampleId}" : "")}.txt") ;
        return File.ReadAllLines(input);
    }
    
    public static string[] GetPartTwoInput(int day, bool exampleFile = false)
    {
        var current = Directory.GetParent(Directory.GetCurrentDirectory())!.Parent!.Parent!.Parent!.FullName;
        var input = Path.Combine(current,"AoC23", "input", $"{day}{(exampleFile ? "e" : "")}_2.txt") ;
        return File.ReadAllLines(input);
    }

}