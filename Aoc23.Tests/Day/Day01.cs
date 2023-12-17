using AoC23.Day01;
using AoC23.Helpers;

namespace AoC23.Tests.Day;

public class Day01
{
    
    public static IEnumerable<object[]> PartOneCases => new List<object[]>
    {
        new object[]{"1ggg6","16" },
        new object[]{"5ttt6","56"},
        new object[]{"55tttt","55"},
        new object[]{"6yy6y777","67"},
        new object[]{"6yy","66"},
        
        new object[]{"1abc2","12"},
        new object[]{"pqr3stu8vwx","38"},
        new object[]{"a1b2c3d4e5f","15"},
        new object[]{"treb7uchet","77"},
    };
    
    [Theory]
    [MemberData(nameof(PartOneCases))]
    public void Day1_1(string input, string expected)
    {
        var result = Solution.GetResult_Part1(input);
        Assert.Equal(expected, result.ToString());
    }

    public static IEnumerable<object[]> PartTwoCases => new List<object[]>
    {
         new object[]{"two1nine", "29" },
         new object[]{"eightwothree", "83" },
         new object[]{"4nineeightseven2", "42" },
         new object[]{"xtwone3four", "24" },
         new object[]{"abcone2threexyz", "13" },
         new object[]{"zoneight234", "14" },
         new object[]{"7pqrstsixteen", "76" },
         new object[]{"9four6dk7gvv", "97" },
         new object[]{"four95qvkvveight5", "45" },
         new object[]{"2tqbxgrrpmxqfglsqjkqthree6nhjvbxpflhr1eightwohr", "22" },
         new object[]{"7two68", "78" },
         new object[]{"nine7twoslseven4sfoursix", "96" },
         new object[]{"fivemnjxbrnsvl3", "53" },
         new object[]{"3qcfxgzsevenone1rv", "31" },
         new object[]{"nine91threepdcthjkmrthreeeightwonsg", "92" },
         new object[]{"fivetglzqdfthreergnseight2lpphhbd", "52" },
         new object[]{"fourtwohldlr6294", "44" },
         new object[]{"qkvc7pvsv6rvsxlqzpjdjkd1eightthree", "73" },
         new object[]{"onefourm5qpfvdnbs", "15" },
         new object[]{"ql8jbzzjpsdgmrjtngrkfdmcsix6eightsix", "86" },
         new object[]{"8nl2", "82" },
         new object[]{"thdreedlmndniXneedighteidght7", "77" },
    };
    
    [Theory]    
    [MemberData(nameof(PartTwoCases))]
    public void Day1_2(string input, string expected)
    {
        var result = Solution.GetResult_Part2(input);
        Assert.Equal(expected, result.ToString());

    }
    
    [Fact]
    public static void Solution_Part1()
    {
        var input = FileHelpers.GetLinesForInput(1);
        var result = Solution.GetResult_Part1(input);
        Assert.Equal(55208,result);
    }
    
    [Fact]
    public static void Solution_Part2()
    {
        var input = FileHelpers.GetLinesForInput(1);
        var result = Solution.GetResult_Part2(input);
        Assert.Equal(54578,result);
    }

}