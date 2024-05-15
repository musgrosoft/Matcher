using Match.Cards;

namespace Match.Players;

public interface IPlayer
{
    string Name { get; }
    void TakeCards(List<Card> cards);
    int TotalCards();
}