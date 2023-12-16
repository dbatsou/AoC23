namespace AoC23.Day02;

public class Game
{
    /// <summary>
    /// Checks the available cubes against the requested cubes for the game;
    /// </summary>
    public bool GameIsPossible =>
        (AvailableBlueCubes >= RequestedBlueCubes) && (AvailableGreenCubes >= RequestedGreenCubes) &&
        (AvailableRedCubes >= RequestedRedCubes);

    /// <summary>
    /// Returns the game id if the game is possible, 0 if not
    /// </summary>
    public int ReturnValue => GameIsPossible ? Id : default;
    public int Id => int.Parse(_input.Split(":")[0].Split(" ")[1]);
    private int AvailableBlueCubes { get; init; }
    public int RequestedBlueCubes { get; private set; }
    public int RequestedRedCubes { get; private set; }
    public int RequestedGreenCubes { get; private set; }

    private readonly string _input;
    private string[] _cubeSets => _input.Split(":")[1].Split(";");
    private int AvailableRedCubes { get; }
    private int AvailableGreenCubes { get; }
    
    public Game(string input, int availableRedCubes = 12, int availableGreenCubes = 13, int availableBlueCubes = 14)
    {
        //Available cubes as directed by the instructions 
        _input = input;
        AvailableRedCubes = availableRedCubes;
        AvailableGreenCubes = availableGreenCubes;
        AvailableBlueCubes = availableBlueCubes;
        ExtractSelectedSets();
    }

    private void ExtractSelectedSets()
    {
        foreach (var set in _cubeSets)
        {
            //Game 79:
            //3 green, 1 blue, 2 red;
            //8 green, 1 blue, 2 red; 2
            //blue, 1 red, 11 green
            foreach (var individualSet in set.Split(","))
            {
                var extractedSetSplit = individualSet.Trim().Split(" ");
                var count = int.Parse(extractedSetSplit[0]);
                var colour = extractedSetSplit[1];

                switch (colour)
                {
                    case "blue":
                        RequestedBlueCubes = count;
                        break;
                    case "red":
                        RequestedRedCubes = count;
                        break;
                    case "green":
                        RequestedGreenCubes = count;
                        break;
                }
            }
            
            if(!GameIsPossible)
                break;
        }
    }
}