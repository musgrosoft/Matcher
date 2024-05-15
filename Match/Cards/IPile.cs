namespace Match.Cards;

public interface IPile
{
    bool AddCard(Card card);
    List<Card> TakeAllCards();
    int CountCards();
}