namespace AoC23.Day04;

public class ScratchcardGame
{
    private readonly List<ScratchcardV2> _cards;
    public int WinningCardsCount { get; private set; }

    public ScratchcardGame(List<ScratchcardV2> cards)
    {
        _cards = cards;
        CalculateWinningCount();
    }

    private void CalculateWinningCount()
    {
        var checkCards = new List<ScratchcardV2>(_cards);
        checkCards.Reverse();
        
        var cardsToCheck = new Stack<ScratchcardV2>(checkCards);
        
        while (cardsToCheck.Count > 0)
        {
            var currentCard = cardsToCheck.Pop();
            
            //that is bad, I could have this in an array of cached adds
            for (var j = 0; j < currentCard.CardPoints; j++)
            {
                var cardToAdd = _cards[currentCard.GameId + j];
                
                cardsToCheck.Push(cardToAdd);
            }

            
            WinningCardsCount += currentCard.CardPoints;
        }

        WinningCardsCount += _cards.Count;
    }

}