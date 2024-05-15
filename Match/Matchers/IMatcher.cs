using Match.Cards;

namespace Match.Matchers;

public interface IMatcher
{
    bool IsMatch(Card card1, Card card2);
}