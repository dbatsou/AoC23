using System.Text;

namespace AoC23.Day03;

public class EngineSchematic
{
    private readonly string _input;
    public int Sum { get; private set; }


    public EngineSchematic(string input)
    {
        _input = input;
        var lines = input.Split(Environment.NewLine);
        int linesCounter = 0;

        for (var loopIndex = 0; loopIndex < lines.Length; loopIndex++)
        {
            var line = lines[loopIndex].Trim();
                var sb = new StringBuilder();
                bool characterRight = default;
                bool characterBelow = default;
                bool characterBelowRight = default;
                bool characterBelowLeft = default;
                bool characterLeft = default;

            for (var charIndex = 0; charIndex < line.Length; charIndex++)
            {
                var currentChar = line[charIndex];
                if (char.IsDigit(currentChar))
                {
                    sb.Append(currentChar);

                    var nextLine = lines[loopIndex + 1];

                    if (charIndex == 0)
                    {
                        characterRight = IsSpecialCharacter(line, charIndex + 1);
                        characterBelow = IsSpecialCharacter(nextLine, charIndex);
                        characterBelowRight = IsSpecialCharacter(nextLine, charIndex + 1);

                        if (loopIndex > 0)
                        {
                            
                        }
                    }
                    else if (charIndex == line.Length - 1)
                    {
                        characterLeft = IsSpecialCharacter(line, charIndex - 1);
                        characterBelow = IsSpecialCharacter(nextLine, charIndex);
                        characterBelowLeft = IsSpecialCharacter(nextLine, charIndex - 1);
                    }
                    else if (charIndex > 0 && charIndex < line.Length - 1)
                    {
                        characterLeft = IsSpecialCharacter(line, charIndex - 1);
                        characterRight = IsSpecialCharacter(line, charIndex + 1);
                        characterBelowLeft = IsSpecialCharacter(nextLine, charIndex - 1);
                        characterBelowRight = IsSpecialCharacter(nextLine, charIndex + 1);
                    }
                }
                else if (currentChar == '.')
                {
                    var increaseSum =
                        characterRight
                        || characterBelow
                        || characterBelowRight
                        || characterBelowLeft
                        || characterLeft;

                    if (increaseSum)
                    {
                        Sum += int.Parse(sb.ToString());
                        characterRight = false;
                        characterBelow = false;
                        characterBelowRight = false;
                        characterBelowLeft = false;
                        characterLeft = false;
                        sb.Clear();
                    }
                }
            }
        }
    }

    private static bool IsSpecialCharacter(string line, int charIndex)
    {
        return !char.IsDigit(line[charIndex]) && line[charIndex] != '.';
    }
}