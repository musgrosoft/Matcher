namespace Match.Cards;

public class Deck : IDeck
{
    private static readonly Random Rnd = new();
    private List<Card> _cards = [];
    
    public void AddCardsToBottom(IEnumerable<Card> cards)
    {
        _cards.AddRange(cards);
    }

    public Card Take()
    {
        var card = _cards.First();

        _cards.RemoveAt(0);

        return card;
    }

    public void Shuffle()
    {
        _cards = _cards.OrderBy(_ => Rnd.Next()).ToList();
    }

    public bool HasMoreCards()
    {
        return _cards.Any();
    }
}