using System.Text;
using AoC23.Helpers;

namespace AoC23.Day01;

public static class Solution
{
    public static int GetResult_Part1(params string[] lines)
    {
        int result = 0;
        StringBuilder? sb = null;
        foreach (var line in lines)
        {
            sb = new StringBuilder();
            var characters = line.Where(char.IsDigit);

            var enumerable = characters.ToList();
            switch (enumerable.Count)
            {
                case 1:
                {
                    var character = enumerable.First();
                    sb.Append($"{enumerable[0]}{enumerable[0]}");
                    break;
                }
                case 2:
                {
                    var character = enumerable.First();
                    sb.Append($"{enumerable[0]}{enumerable[1]}");
                    break;
                }
                case > 2:
                    sb.Append($"{enumerable[0]}{enumerable[^1]}");
                    break;
            }

            result += int.Parse(sb.ToString());
        }

        return result;
    }


    public static int GetResult_Part2(params string[] lines)
    {
        var result = 0;

        foreach (var input in lines)
        {
            var _numberWords = NumHelpers.NumberWords;
            var words = NumHelpers.NumberWords.Keys.ToList();
            StringBuilder stringBuilder = new();
            string returned = string.Empty;
            int count = 0;

            //what if is only words
            var onlyLetters = input.All(char.IsLetter);

            if (onlyLetters)
            {
                var inputArray = input.ToCharArray();
                var inputLength = inputArray.Length; // length of the char array of the input
                for (var index = 0; index < inputLength; index++)
                {
                    var current = inputArray[index];
                    stringBuilder.Append(current);

                    var currentStringBuilderValue = stringBuilder.ToString();
                    var currentStringIsANumber = words.Contains(currentStringBuilderValue);
                    if (currentStringIsANumber)
                    {
                        returned += _numberWords[currentStringBuilderValue];
                        stringBuilder.Clear();
                        stringBuilder.Append(current);
                    }

                    //if last iteration and currentStringBuilderValue is not empty
                    //try removing the first character as that was from previous iteration
                    if (index != inputLength - 1 || currentStringBuilderValue == string.Empty) continue;

                    currentStringBuilderValue = currentStringBuilderValue.Substring(1);
                    returned += _numberWords[currentStringBuilderValue];
                    stringBuilder.Clear();
                }
            }
            else if (!onlyLetters)
            {
                while (count < input.Length)
                {
                    var currentChar = input[count];
                    if (char.IsDigit(currentChar))
                    {
                        returned += currentChar;
                        count++;
                        continue;
                    }

                    stringBuilder.Append(currentChar);
                    var sbValue = stringBuilder.ToString();
                    var currentValueHasNumberIn = words.FirstOrDefault(x => sbValue.Contains(x));
                    if (currentValueHasNumberIn != null)
                    {
                        returned += _numberWords[currentValueHasNumberIn.ToString()];
                        stringBuilder = new StringBuilder();
                        stringBuilder.Append(currentValueHasNumberIn.Last());
                    }

                    count++;
                }
            }

            if (stringBuilder.Length > 0 && words.Contains(stringBuilder.ToString()))
            {
                returned += _numberWords[stringBuilder.ToString()];
            }

            string finalValue = returned.Length switch
            {
                1 => $"{returned}{returned}",
                2 => returned,
                _ => $"{returned.First()}{returned.Last()}"
            };

            result += int.Parse(finalValue);
        }

        return result;
    }
}