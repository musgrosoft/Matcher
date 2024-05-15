using Match.Cards;

namespace Match.Matchers;

public class ValueMatcher : IMatcher
{
    public bool IsMatch(Card card1, Card card2)
    {
        return card1.Value == card2.Value;
    }
}