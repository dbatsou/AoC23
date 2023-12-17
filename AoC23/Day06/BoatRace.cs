using System.Numerics;

namespace AoC23.Day06;

public class BoatRace
{
    public readonly BigInteger Duration;
    public readonly BigInteger Record;
    public int WaysToWin => CalculateWaysToWin();

    private BoatRace(BigInteger duration, BigInteger record)
    {
        Duration = duration;
        Record = record;
    }

    private int CalculateWaysToWin()
    {
        var count = 0;
        for (int i = 0; i <= Duration; i++)
        {
            var availableSeconds = Duration - i;
            var distanceCovered = i * availableSeconds;

            if (distanceCovered > Record)
                count++;
        }

        return count;
    }

    public static IEnumerable<BoatRace> ExtractRaces(string[] input)
    {
        var timingsPerRace = input[0].Split(":")[1].Split(" ").Where(x => x != "").Select(int.Parse);
        var recordPerRace = input[1].Split(":")[1].Split(" ").Where(x => x != "").Select(int.Parse);

        return timingsPerRace.Zip(recordPerRace, (timing, record) => new BoatRace(timing,record)).ToList();
    }

    public static BoatRace ExtractRace(string[] input)
    {
        var timingsPerRace = BigInteger.Parse(input[0].Split(":")[1].Replace(" ", "").Trim());
        var recordPerRace = BigInteger.Parse(input[1].Split(":")[1].Replace(" ", "").Trim());
        return new BoatRace(timingsPerRace, recordPerRace);

    }
    public static int CalculateWinningWaysProduct(IEnumerable<BoatRace> lst) => lst.Aggregate(1, (a, b) => a * b.WaysToWin);
}
