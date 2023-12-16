using AoC23.Day02;

namespace Aoc23.Tests.Day;

public static class Day02
{
    public record TestCaseSimple(string input, bool expectedGamePossible, int expectedReturnValue);
    private static readonly List<TestCaseSimple> _casesSimple = new()
    {
        new("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",  true, 1),
        new("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",  true, 2),
        new("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",  true, 5),
        new("Game 79: 3 green, 1 blue, 2 red; 8 green, 1 blue, 2 red; 2 blue, 1 red, 11 green",true, 79),
        new("Game 1: 7 blue, 4 red, 11 green; 2 red, 2 blue, 7 green; 2 red, 13 blue, 8 green; 18 blue, 7 green, 5 red", false, 0),
        // new("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false, 0),
        // new("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",  false, 0),
        // new("Game 10: 16 blue, 8 green; 2 red, 4 green, 1 blue; 15 blue; 4 red, 5 green, 4 blue",  false, 0),
        // new("Game 18: 7 blue, 8 red; 1 blue, 2 red; 1 green, 2 blue",  true, 18),
        // new("Game 2: 3 green, 4 red, 4 blue; 6 red, 4 green, 4 blue; 2 blue, 4 green, 3 red",  false, 0),
        // new("Game 16: 8 red, 4 blue, 6 green; 14 blue, 9 red, 10 green; 1 red, 5 blue, 8 green; 14 blue, 11 green, 3 red",  false, 0),
        // new("Game 17: 20 blue, 5 red, 4 green; 3 red, 14 blue; 4 red, 4 blue, 4 green; 12 blue, 5 red, 3 green",  false, 0),
        // new("Game 24: 1 red, 3 blue; 2 blue; 1 green, 1 red, 3 blue; 1 red, 1 green",  true, 24),
        // new("Game 86: 5 red, 6 green; 9 red, 4 green; 7 green, 1 blue, 2 red",  false, 0),
        // new("Game 41: 3 red, 1 green; 10 green, 4 blue, 5 red; 8 blue, 5 red",  false, 0),
        // new("Game 47: 6 red, 6 blue; 14 blue, 7 green, 2 red; 8 blue, 3 red",  false, 0),
        
        // new("Game 1: 7 blue, 4 red, 11 green; 2 red, 2 blue, 7 green; 2 red, 13 blue, 8 green; 18 blue, 7 green, 5 red",  false, 0),
        // new("Game 2: 3 green, 4 red, 4 blue; 6 red, 4 green, 4 blue; 2 blue, 4 green, 3 red",  false, 0),
        // new("Game 3: 1 red, 2 green, 3 blue; 1 red, 2 green; 2 green, 3 red; 1 blue, 2 red",  true, 3),
        // new("Game 4: 1 red, 15 green; 1 green, 2 blue; 12 green, 1 red, 2 blue; 14 green; 2 green, 1 blue, 2 red",  false, 0),
        // new("Game 5: 8 red; 7 red; 11 red, 4 green; 1 blue, 8 red; 6 red, 2 green, 1 blue; 8 green, 13 red, 1 blue",  false, 0),
        // new("Game 6: 3 blue, 2 red, 6 green; 2 red, 8 green, 1 blue; 1 red, 3 blue",  false, 0),
        // new("Game 7: 5 green, 1 red, 1 blue; 6 blue, 12 red; 6 red, 7 green; 3 green, 1 blue",  false, 0),
        // new("Game 8: 10 red, 6 green; 4 blue, 6 green, 5 red; 8 green, 5 red, 5 blue; 2 red, 4 blue",  false, 0),
        // new("Game 9: 11 blue, 13 red, 3 green; 13 red, 1 green, 6 blue; 8 blue, 4 green, 5 red; 16 red, 7 green, 10 blue; 16 red, 5 green, 6 blue; 17 red, 6 blue",  false, 0),
        // new("Game 10: 16 blue, 8 green; 2 red, 4 green, 1 blue; 15 blue; 4 red, 5 green, 4 blue",  false, 0),
        // new("Game 11: 3 blue, 8 red, 10 green; 10 red, 6 green; 1 red, 1 green; 13 red, 1 green, 1 blue; 3 green, 7 red; 2 blue, 6 green, 2 red",  false, 0),
        // new("Game 12: 1 red, 10 green; 4 red, 6 green, 1 blue; 9 green, 1 blue, 7 red; 1 blue, 13 green, 2 red; 2 blue, 5 red, 11 green",  false, 0),
        // new("Game 13: 1 red, 5 blue; 1 red, 6 green; 2 blue, 1 red; 2 blue, 1 red, 2 green; 5 green, 2 blue",  true, 13),
        // new("Game 14: 4 green; 8 blue, 1 red, 2 green; 7 red, 2 green, 4 blue; 4 blue, 7 green; 7 blue, 2 green, 1 red; 7 blue, 5 red",  false, 0),
        // new("Game 15: 10 green, 3 red; 8 blue, 14 green, 3 red; 4 red, 1 green, 12 blue",  false, 0),
        // new("Game 16: 8 red, 4 blue, 6 green; 14 blue, 9 red, 10 green; 1 red, 5 blue, 8 green; 14 blue, 11 green, 3 red",  false, 0),
        // new("Game 17: 20 blue, 5 red, 4 green; 3 red, 14 blue; 4 red, 4 blue, 4 green; 12 blue, 5 red, 3 green",  false, 0),
        // new("Game 18: 7 blue, 8 red; 1 blue, 2 red; 1 green, 2 blue",  true, 18),
        // new("Game 19: 14 green, 4 blue; 6 green; 12 green, 5 blue; 12 green, 1 red, 1 blue; 4 blue, 10 green",  false, 0),
        // new("Game 20: 3 green, 4 blue, 4 red; 13 blue, 1 red, 2 green; 13 blue, 9 green, 9 red",  false, 0),
        // new("Game 21: 4 green, 2 blue, 2 red; 3 green, 2 blue; 1 blue, 5 green; 1 blue, 2 red, 3 green; 1 green, 1 blue, 2 red; 6 blue, 1 green",  false, 0),
        // new("Game 22: 4 red, 17 green; 15 green, 3 blue, 2 red; 4 blue, 7 red, 11 green; 16 green, 4 red; 3 blue, 2 red",  false, 0),
        // new("Game 23: 19 green, 2 blue, 3 red; 1 red, 2 blue, 2 green; 2 blue, 10 green, 11 red",  false, 0),
        // new("Game 24: 1 red, 3 blue; 2 blue; 1 green, 1 red, 3 blue; 1 red, 1 green",  true, 24),
        // new("Game 25: 12 green, 2 red, 10 blue; 6 green, 3 red; 3 green, 18 blue, 3 red; 17 green, 3 red, 18 blue",  false, 0),
        // new("Game 26: 4 red, 12 blue, 5 green; 3 green, 5 red, 1 blue; 6 blue, 4 green, 1 red; 6 blue, 7 green; 3 green, 5 red, 2 blue; 1 green, 2 blue, 9 red",  false, 0),
        // new("Game 27: 1 red, 9 green; 3 green; 9 green, 2 blue, 1 red; 10 green, 1 blue; 1 red, 5 green, 3 blue",  false, 0),
        // new("Game 28: 10 red, 8 green; 2 blue, 4 green, 7 red; 2 green, 9 red, 1 blue",  false, 0),
        // new("Game 29: 5 blue, 5 green, 3 red; 1 green, 2 blue, 3 red; 2 green, 3 blue, 5 red; 3 red, 11 blue",  false, 0),
        // new("Game 30: 11 red, 5 green; 4 blue, 3 green, 5 red; 6 blue, 3 green, 5 red",  false, 0),
        // new("Game 31: 2 blue, 8 green, 14 red; 9 green; 1 red, 1 blue, 4 green; 2 green, 10 red; 1 red, 10 green, 2 blue; 8 green, 14 red",  false, 0),
        // new("Game 32: 14 green, 6 red, 6 blue; 1 red, 2 blue, 15 green; 2 red, 18 green, 1 blue",  false, 0),
        // new("Game 33: 16 green, 4 red; 18 green, 3 red; 5 red, 10 green; 5 red, 19 green; 11 green, 4 red; 11 red, 1 blue, 2 green",  false, 0),
        // new("Game 34: 1 blue, 11 red; 5 red, 4 green; 4 green, 1 blue, 12 red; 2 blue, 1 green, 7 red; 3 green, 1 blue, 12 red",  false, 0),
        // new("Game 35: 5 red, 1 blue; 1 blue, 1 red; 2 blue, 2 green, 15 red; 7 red, 2 green; 3 blue, 1 green, 1 red; 16 red, 3 blue, 1 green",  false, 0),
        // new("Game 36: 10 green, 16 red; 2 blue, 14 green, 6 red; 1 blue, 8 green, 12 red",  false, 0),
        // new("Game 37: 17 green, 14 blue; 10 green, 12 blue; 10 blue, 1 red, 8 green",  false, 0),
        // new("Game 38: 9 blue, 2 green; 5 blue, 1 green, 5 red; 6 blue, 2 green, 7 red; 17 red, 1 green, 7 blue; 1 green, 9 blue, 16 red",  false, 0),
        // new("Game 39: 2 red, 13 blue, 10 green; 5 blue, 15 green, 1 red; 13 blue, 5 green; 3 red, 6 blue, 2 green; 17 green, 1 blue, 4 red; 4 red, 1 blue, 11 green",  false, 0),
        // new("Game 40: 4 green, 12 blue; 5 red, 13 blue, 1 green; 4 green, 7 red; 7 blue, 2 green",  false, 0),
        // new("Game 41: 3 red, 1 green; 10 green, 4 blue, 5 red; 8 blue, 5 red",  false, 0),
        // new("Game 42: 8 blue, 12 red, 5 green; 8 red, 5 green, 4 blue; 3 green, 13 red; 8 blue, 16 red; 12 red, 3 green, 1 blue; 2 blue, 2 green, 6 red",  false, 0),
        // new("Game 43: 5 blue, 4 red; 10 red, 6 blue; 12 red, 2 blue, 1 green; 7 blue, 12 red, 1 green",  false, 0),
        // new("Game 44: 11 blue, 5 red; 2 red, 13 green, 5 blue; 7 red, 7 blue, 11 green",  false, 0),
        // new("Game 45: 7 red, 6 blue; 5 blue, 6 green; 5 green, 5 blue, 7 red; 4 red, 9 green, 12 blue; 9 blue, 12 green, 1 red",  false, 0),
        // new("Game 46: 2 green, 7 blue, 20 red; 18 green, 2 blue; 8 blue, 1 red, 3 green; 6 green, 1 blue; 2 red, 6 blue, 4 green",  false, 0),
        // new("Game 47: 6 red, 6 blue; 14 blue, 7 green, 2 red; 8 blue, 3 red",  false, 0),
        // new("Game 48: 1 red, 5 blue; 3 blue, 15 green, 2 red; 6 blue, 1 red, 13 green; 6 green, 4 blue, 3 red; 11 green, 3 blue",  false, 0),
        // new("Game 49: 1 green, 15 blue, 3 red; 15 green, 6 blue; 12 green, 2 red, 8 blue; 3 green, 16 blue",  false, 0),
        // new("Game 50: 8 blue, 7 red, 1 green; 6 blue, 1 green, 2 red; 3 red, 7 blue; 4 blue, 6 red, 1 green",  false, 0),
        // new("Game 51: 2 red, 5 blue; 2 red, 10 green; 11 green, 1 blue; 9 green, 1 blue, 2 red; 5 blue, 11 green; 1 red, 8 green, 1 blue",  false, 0),
        // new("Game 52: 1 green, 1 red, 15 blue; 17 blue, 1 red; 5 red, 1 green; 19 blue, 6 red, 3 green; 5 blue, 1 green",  false, 0),
        // new("Game 53: 1 blue, 12 red, 6 green; 3 red, 7 green, 3 blue; 2 blue, 7 red, 5 green; 4 red, 3 blue, 19 green; 10 red, 12 green, 2 blue; 5 blue, 7 red, 14 green",  false, 0),
        // new("Game 54: 12 green, 1 red, 4 blue; 3 blue, 5 red, 8 green; 9 green, 6 blue; 3 green, 2 red, 11 blue; 3 green, 10 blue, 7 red; 2 red, 3 green, 4 blue",  false, 0),
        // new("Game 55: 5 red, 3 blue; 4 blue, 6 green; 10 blue, 1 green; 7 green, 4 red, 14 blue; 2 red, 9 blue, 10 green; 5 red, 10 blue, 10 green",  false, 0),
        // new("Game 56: 3 green, 11 blue; 4 blue, 10 green, 8 red; 2 blue, 5 green, 2 red; 1 blue, 1 green, 8 red; 5 green, 7 red, 3 blue",  false, 0),
        // new("Game 57: 2 green, 2 blue, 3 red; 8 red, 5 green, 2 blue; 16 red, 12 blue, 7 green; 13 blue, 6 red, 2 green; 12 red, 1 green",  false, 0),
        // new("Game 58: 2 green, 3 blue, 8 red; 3 green, 4 blue, 7 red; 2 blue, 11 red, 4 green; 4 green, 1 blue, 2 red; 3 green, 3 red, 2 blue",  false, 0),
        // new("Game 59: 10 red, 6 blue, 2 green; 2 green, 6 blue, 14 red; 3 green, 11 red, 7 blue; 1 blue, 1 green",  false, 0),
        // new("Game 60: 5 blue, 10 red; 4 blue, 12 red; 2 green, 3 red, 4 blue",  false, 0),
        // new("Game 61: 4 blue, 1 green; 10 blue, 2 red; 6 blue, 1 red; 1 green, 7 red; 5 blue, 5 red",  false, 0),
        // new("Game 62: 6 blue, 7 red, 1 green; 7 blue, 7 green, 15 red; 14 green, 16 red, 2 blue; 2 blue, 17 red; 4 red, 11 green, 6 blue; 13 green, 16 red, 5 blue",  false, 0),
        // new("Game 63: 4 red, 13 green, 1 blue; 2 green, 5 blue, 10 red; 3 green, 8 red; 1 blue, 3 red, 11 green; 1 red, 7 blue",  false, 0),
        // new("Game 64: 12 green, 1 blue; 8 red, 1 blue, 10 green; 11 green, 1 blue, 3 red; 10 green, 2 red, 1 blue; 1 blue, 9 green, 8 red",  false, 0),
        // new("Game 65: 5 green, 2 red; 7 blue, 5 red, 10 green; 9 green, 8 blue; 3 blue, 4 red, 8 green; 11 green, 6 red, 16 blue",  false, 0),
        // new("Game 66: 8 green, 1 red, 4 blue; 10 green, 5 blue, 7 red; 5 blue, 3 red, 6 green; 4 blue, 12 green, 6 red; 16 green, 3 red; 16 green, 7 red, 4 blue",  false, 0),
        // new("Game 67: 6 green; 7 red, 1 green, 5 blue; 10 red, 13 green, 3 blue; 8 green, 11 red, 6 blue; 14 red, 5 green, 7 blue",  false, 0),
        // new("Game 68: 1 red, 8 green, 3 blue; 1 green, 1 red, 1 blue; 1 green, 11 blue, 1 red",  false, 0),
        // new("Game 69: 2 red, 4 green, 1 blue; 4 blue, 10 green; 4 green, 1 blue, 2 red; 12 green, 5 blue; 6 blue, 3 green",  false, 0),
        // new("Game 70: 1 blue, 3 green, 2 red; 1 green, 2 blue; 5 green, 1 red; 2 blue, 4 green; 1 red, 5 green",  false, 0),
        // new("Game 71: 6 blue, 3 red, 12 green; 2 red, 8 green, 3 blue; 8 green, 8 blue; 7 blue, 1 red, 9 green; 2 green, 4 blue, 1 red; 3 red, 7 blue, 8 green",  false, 0),
        // new("Game 72: 8 red, 7 blue, 6 green; 2 red, 8 blue, 7 green; 2 red, 5 blue, 1 green; 4 green, 6 blue, 1 red; 11 green, 13 red, 3 blue; 8 green, 11 red, 2 blue",  false, 0),
        // new("Game 73: 7 blue, 17 red, 4 green; 1 red, 4 green, 2 blue; 3 red, 4 blue, 4 green; 5 blue, 5 red; 6 red, 2 blue; 11 red, 1 green, 4 blue",  false, 0),
        // new("Game 74: 3 red, 2 green; 4 red, 12 blue, 4 green; 7 red, 6 blue, 10 green",  false, 0),
        // new("Game 75: 6 blue, 7 green; 8 green, 9 blue, 1 red; 6 red, 4 blue, 9 green; 10 red, 9 blue, 4 green; 6 red, 2 blue, 1 green; 7 green",  false, 0),
        // new("Game 76: 10 red, 8 green; 2 red, 2 blue, 5 green; 1 red, 1 blue, 1 green; 9 red, 11 green, 2 blue; 2 blue, 9 green, 3 red; 6 green, 14 red",  false, 0),
        // new("Game 77: 9 blue, 1 red, 3 green; 8 blue, 17 green, 4 red; 5 green, 1 blue, 2 red; 6 green, 1 red, 9 blue; 4 green, 10 red; 9 red, 3 blue",  false, 0),
        // new("Game 78: 5 green, 10 blue; 2 green, 5 blue, 11 red; 1 red, 1 green, 6 blue; 1 red, 8 blue, 4 green",  false, 0),
        // new("Game 79: 3 green, 1 blue, 2 red; 8 green, 1 blue, 2 red; 2 blue, 1 red, 11 green",  false, 0),
        // new("Game 80: 12 blue, 3 green; 6 red, 4 green, 13 blue; 4 blue, 8 red; 3 green, 4 blue",  false, 0),
        // new("Game 81: 1 green, 5 blue; 1 green, 3 blue, 1 red; 1 blue, 1 red, 3 green; 6 blue, 5 green",  false, 0),
        // new("Game 82: 2 green, 1 blue; 10 blue, 1 red, 6 green; 4 green, 20 blue, 1 red; 20 blue, 2 green, 1 red",  false, 0),
        // new("Game 83: 2 green, 9 blue, 10 red; 12 red, 11 blue, 4 green; 11 blue, 8 red, 3 green; 17 green, 4 blue; 12 green, 4 red, 6 blue; 1 red, 11 green, 8 blue",  false, 0),
        // new("Game 84: 7 green, 15 red, 15 blue; 4 blue, 3 green, 18 red; 2 blue, 1 red, 2 green; 8 blue, 19 red, 5 green; 11 blue, 3 red; 9 red, 2 blue",  false, 0),
        // new("Game 85: 14 green, 3 red, 16 blue; 3 blue, 6 green; 12 green, 6 blue, 2 red",  false, 0),
        // new("Game 86: 5 red, 6 green; 9 red, 4 green; 7 green, 1 blue, 2 red",  false, 0),
        // new("Game 87: 10 blue, 7 red, 1 green; 12 blue, 14 red; 7 blue, 7 red",  false, 0),
        // new("Game 88: 5 red, 10 green, 5 blue; 10 green, 2 red, 8 blue; 2 red, 14 green, 4 blue",  false, 0),
        // new("Game 89: 1 blue, 6 red, 12 green; 9 red, 13 green, 3 blue; 11 green, 6 red, 3 blue",  false, 0),
        // new("Game 90: 1 green, 8 blue, 10 red; 10 blue, 7 green; 6 blue, 15 red, 1 green; 1 blue, 16 red, 4 green",  false, 0),
        // new("Game 91: 8 red, 9 green, 2 blue; 2 red, 15 blue, 2 green; 15 blue, 1 red, 5 green; 1 green, 6 red, 10 blue",  false, 0),
        // new("Game 92: 10 blue, 4 red; 9 blue, 3 red, 7 green; 8 blue, 16 green, 3 red; 16 green, 16 blue",  false, 0),
        // new("Game 93: 1 blue, 2 green, 1 red; 4 red, 7 green, 12 blue; 6 green, 3 blue, 4 red; 8 blue, 4 red, 12 green; 5 red, 8 green; 1 red, 18 blue, 10 green",  false, 0),
        // new("Game 94: 1 blue, 5 red, 6 green; 7 red, 6 green, 1 blue; 8 red, 11 green; 12 green, 7 red, 1 blue; 7 red, 8 green",  false, 0),
        // new("Game 95: 10 red, 7 green; 2 green, 1 blue, 10 red; 6 green, 5 red, 1 blue",  false, 0),
        // new("Game 96: 3 blue, 12 red, 3 green; 13 red, 9 blue; 2 green, 5 red, 13 blue; 2 red, 18 blue, 4 green; 6 red, 6 blue, 7 green; 3 green, 15 red, 18 blue",  false, 0),
        // new("Game 97: 4 red, 3 green; 2 blue, 4 red, 5 green; 3 red, 3 green",  true, 97),
        // new("Game 98: 2 red, 19 blue; 2 blue; 11 blue, 2 red; 3 green, 5 blue, 1 red; 2 red, 1 blue; 17 blue",  false, 0),
        // new("Game 99: 2 red, 16 blue, 1 green; 2 green, 12 blue, 6 red; 1 red, 3 green, 3 blue; 8 red, 1 green; 2 red, 9 blue; 1 green, 7 red, 9 blue",  false, 0),
        // new("Game 100: 8 green, 3 red; 7 green, 4 red; 1 red, 7 green, 2 blue; 1 green, 2 red",  false, 0),
        // new("",  false, 0),
    };

    public static IEnumerable<object[]> simpleCaseSource => new List<object[]>
    {
        new object[] { _casesSimple, 87 },
    };

    [Theory]
    [MemberData(nameof(simpleCaseSource))]
    public static void ValidateClassPropertiesAfterExtractionSimplercase(List<TestCaseSimple> cases, int expected)
    {
        var sumOfIdsOfPossibleGames = 0;

        Assert.All(cases, c =>
        {
            var game = new Game(c.input);
            sumOfIdsOfPossibleGames += game.ReturnValue;

            Assert.Equal(c.expectedGamePossible, game.GameIsPossible);
            Assert.Equal(c.expectedReturnValue, game.ReturnValue);
        });
        
        Assert.Equal(expected,sumOfIdsOfPossibleGames);

    }

}
