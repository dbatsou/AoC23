using AoC23.Day04;
using AoC23.Helpers;

namespace AoC23.Tests.Day;

public class Day04
{
    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",8)]
    [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",2)]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",2)]
    [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",1)]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",0)]
    [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",0)]
    public void Day4_1(string input, int expected)
    {
        var c = new Scratchcard(input);
        
        Assert.Equal(expected,c.CardPoints);

        var gameId = int.Parse(input.Split(":")[0].Split(" ")[1]);
        Assert.Equal(gameId,c.GameId);
        Assert.Equal(expected,c.CardPoints);

    }
    
    [Fact]
    public void Solution_part1()
    {
        var input = FileHelpers.GetPartOneInput(4);
        var result = AoC23.Day04.Solution.GetResult_Part1(input);
        
        Assert.Equal(24542,result);
    }
    
    [Fact]    
    public void Day4_2_validate_card_points()
    {
        var cards = ScratchCards().ToList();

        var game = new ScratchcardGame(cards);
        
        Assert.Equal(4,cards[0].CardPoints);
        Assert.Equal(2,cards[1].CardPoints);
        Assert.Equal(2,cards[2].CardPoints);
        Assert.Equal(1,cards[3].CardPoints);
        Assert.Equal(0,cards[4].CardPoints);
        Assert.Equal(0,cards[5].CardPoints);
    }
    
    [Fact]    
    public void Day4_2_total_winning_cards_example()
    {
        var cards = ScratchCards().ToList();

        var game = new ScratchcardGame(cards);
        
        Assert.Equal(30,game.WinningCardsCount);
    }
    
    [Fact]
    public void Solution_part2()
    {
        var input = FileHelpers.GetPartOneInput(4);
        
        var result = Solution.GetResult_Part2(input);

        Assert.Equal(8736438,result);
    }

    IEnumerable<ScratchcardV2> ScratchCards()
    {
        var cards = new List<string>()
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
        };
        return cards.Select(x => new ScratchcardV2(x));
    }
    
}