namespace Match.Cards;

public readonly struct Card(Suit suit, Value value)
{
    public Value Value { get; } = value;
    public Suit Suit { get; } = suit;
}