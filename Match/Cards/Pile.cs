using Match.Matchers;
using Match.Utils;

namespace Match.Cards;

public class Pile(IMatcher matcher, ILogger logger) : IPile
{
    private readonly List<Card> _cards = new();

    public bool AddCard(Card card)
    {
        _cards.Add(card);

        logger.WriteLine($"{_cards.Count}: {card.Value} {card.Suit}");

        return IsMatch();
    }

    public List<Card> TakeAllCards()
    {
        var takenCards = new List<Card>();
        takenCards.AddRange(_cards);
        _cards.Clear();
        return takenCards;
    }

    public int CountCards()
    {
        return _cards.Count;
    }

    private bool IsMatch()
    {
        if (_cards.Count > 1)
        {
            var lastTwoCards = _cards.TakeLast(2).ToList();
            return matcher.IsMatch(lastTwoCards[0], lastTwoCards[1]);
        }

        return false;
    }

}