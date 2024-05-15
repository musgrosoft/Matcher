namespace Match.Cards;

public class FullPack
{
    public List<Card> Cards { get; } = [];

    public FullPack()
    {
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Value value in Enum.GetValues(typeof(Value)))
            {
                Cards.Add(new Card(suit, value));
            }
        }

    }
}