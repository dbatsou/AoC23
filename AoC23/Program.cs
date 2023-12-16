﻿// See https://aka.ms/new-console-template for more information

using AoC23.Day01;

Console.WriteLine("Hello, World!");


Console.WriteLine($"Day #1 - Part 1 - {Solution.GetResult_Part1(File.ReadAllLines("Input/01.txt"))}");
Console.WriteLine($"Day #1 - Part 2 - {Solution.GetResult_Part2(File.ReadAllLines("Input/01.txt"))}");

Console.WriteLine($"Day #2 - Part 1 - {AoC23.Day02.Solution.GetResult_Part1(File.ReadAllLines("Input/02.txt"))}");
