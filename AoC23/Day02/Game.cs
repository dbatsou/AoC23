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

    private int Id => int.Parse(_input.Split(":")[0].Split(" ")[1]);
    private int AvailableBlueCubes { get; init; }
    private int RequestedBlueCubes { get; set; }
    private int RequestedRedCubes { get; set; }
    private int RequestedGreenCubes { get; set; }
    private int AvailableRedCubes { get; }
    private int AvailableGreenCubes { get; }

    private readonly string _input;
    private IEnumerable<string> _cubeSets => _input.Split(":")[1].Split(";");
    
    //Part 2 
    private int FewestBlueCubes { get; set; }
    private int FewestRedCubes { get; set; }
    private int FewestGreenCubes { get; set; }
    public int FewestCubesPower => FewestBlueCubes * FewestRedCubes * FewestGreenCubes;

    public Game(string input, int availableRedCubes = 12, int availableGreenCubes = 13, int availableBlueCubes = 14)
    {
        _input = input;
        //Available cubes as directed by the instructions 
        AvailableRedCubes = availableRedCubes;
        AvailableGreenCubes = availableGreenCubes;
        AvailableBlueCubes = availableBlueCubes;
        ExtractSelectedSets();
        DetectFewestCubes();
    }

    private void ExtractSelectedSets()
    {
        foreach (var set in _cubeSets)
        {
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

            if (!GameIsPossible) break;
        }
    }

    private void DetectFewestCubes()
    {
        foreach (var set in _cubeSets)
        {
            foreach (var individualSet in set.Split(","))
            {
                var extractedSetSplit = individualSet.Trim().Split(" ");
                var count = int.Parse(extractedSetSplit[0]);
                var colour = extractedSetSplit[1];

                switch (colour)
                {
                    case "blue" when count > FewestBlueCubes:
                        FewestBlueCubes = count;
                        break;
                    case "red" when count > FewestRedCubes:
                        FewestRedCubes = count;
                        break;
                    case "green" when count > FewestGreenCubes:
                        FewestGreenCubes = count;
                        break;
                }
            }
        }

    }
}