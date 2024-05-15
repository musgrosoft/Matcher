using Match.Cards;

namespace Match.Players;

public class Player(string name) : IPlayer
{
    public string Name { get; } = name;
    private readonly List<Card> _cards = [];

    public void TakeCards(List<Card> cards)
    {
        _cards.AddRange(cards);
    }

    public int TotalCards()
    {
        return _cards.Count;
    }
}