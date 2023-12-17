namespace AoC23.Day06;

public class BoatRace
{
    private readonly int _duration;
    private readonly int _record;

    private BoatRace(int duration, int record)
    {
        _duration = duration;
        _record = record;
    }

    private int CalculateWaysToWin()
    {
        var count = 0;
        for (int i = 0; i <= _duration; i++)
        {
            var secondsPressed = i;
            var availableSeconds = _duration - secondsPressed;
            var distanceCovered = secondsPressed * availableSeconds;

            if (distanceCovered > _record)
                count++;
        }

        return count;
    }

    public int WaysToWin => CalculateWaysToWin();


    public static IEnumerable<BoatRace> ExtractRaces(string[] input)
    {
        var timingsPerRace = input[0].Split(":")[1].Split(" ").Where(x => x != "").Select(int.Parse);
        var recordPerRace = input[1].Split(":")[1].Split(" ").Where(x => x != "").Select(int.Parse);

        return timingsPerRace.Zip(recordPerRace, (timing, record) => new BoatRace(timing,record)).ToList();
    }

    public static int CalculateWinningWaysProduct(IEnumerable<BoatRace> lst) => lst.Aggregate(1, (a, b) => a * b.WaysToWin);
}