namespace Match.Cards;

public interface IDeck
{
    void AddCardsToBottom(IEnumerable<Card> cards);
    Card Take();
    void Shuffle();
    bool HasMoreCards();
}