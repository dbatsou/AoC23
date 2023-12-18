using System.Numerics;

namespace AoC23.Day08;

public static class Solution
{
    public static BigInteger GetResult_Part1(params string[] input) =>
        new PuzzleMap(input).StepsToEnd;
}