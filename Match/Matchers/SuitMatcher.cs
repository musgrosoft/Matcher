using Match.Cards;

namespace Match.Matchers;

public class SuitMatcher : IMatcher
{
    public bool IsMatch(Card card1, Card card2)
    {
        return card1.Suit == card2.Suit;
    }
}