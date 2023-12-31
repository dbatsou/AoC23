﻿// See https://aka.ms/new-console-template for more information

using AoC23.Helpers;

Console.WriteLine("Hello, World!");

Console.WriteLine($"Day #1 - Part 1 - {AoC23.Day01.Solution.GetResult_Part1(FileHelpers.GetPartOneInput(1))}");
Console.WriteLine($"Day #1 - Part 2 - {AoC23.Day01.Solution.GetResult_Part1(FileHelpers.GetPartOneInput(1))}");

Console.WriteLine($"Day #2 - Part 1 - {AoC23.Day02.Solution.GetResult_Part1(FileHelpers.GetPartOneInput(2))}");
Console.WriteLine($"Day #2 - Part 2 - {AoC23.Day02.Solution.GetResult_Part1(FileHelpers.GetPartOneInput(2))}");

Console.WriteLine($"Day #3 - Part 1 - {AoC23.Day03.Solution.GetResult_Part1(File.ReadAllText("Input/03.txt"))}");

Console.WriteLine($"Day #4 - Part 1 - {AoC23.Day04.Solution.GetResult_Part1(FileHelpers.GetPartOneInput(4))}");
Console.WriteLine($"Day #4 - Part 2 - {AoC23.Day04.Solution.GetResult_Part2(FileHelpers.GetPartOneInput(4))}");

Console.WriteLine($"Day #6 - Part 1 - {AoC23.Day06.Solution.GetResult_Part1(FileHelpers.GetPartOneInput(6))}");
Console.WriteLine($"Day #6 - Part 2 - {AoC23.Day06.Solution.GetResult_Part2(FileHelpers.GetPartOneInput(6))}");


Console.WriteLine($"Day #8 - Part 1 - {AoC23.Day08.Solution.GetResult_Part1(FileHelpers.GetPartOneInput(8))}");
