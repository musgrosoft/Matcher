using Moq;
using Xunit;
using Match.Matchers;
using Match.Cards;
using Match.Utils;

namespace Match.Tests;

public class PileTests
{
    private readonly Mock<ILogger> _logger;
    private readonly Mock<IMatcher> _matcher;
    private readonly Pile _pile;

    public PileTests()
    {
        _logger = new Mock<ILogger>();
        _matcher = new Mock<IMatcher>();

        _pile = new Pile(_matcher.Object, _logger.Object);
    }

    [Fact]
    public void ShouldCountCardsAddedToPile()
    {
        //Given

        //When
        _pile.AddCard(new Card(Suit.Spades, Value.Ace));
        _pile.AddCard(new Card(Suit.Spades, Value.Two));
        _pile.AddCard(new Card(Suit.Spades, Value.Three));

        //Then
        Assert.Equal(3,_pile.CountCards());
    }

    [Fact]
    public void ShouldReturnAllCardsFromPile()
    {
        //Given

        //When
        _pile.AddCard(new Card(Suit.Spades, Value.Ace));
        _pile.AddCard(new Card(Suit.Hearts, Value.Two));
        _pile.AddCard(new Card(Suit.Diamonds, Value.Three));

        var takenCards = _pile.TakeAllCards();

        //Then
        Assert.Equal(3, takenCards.Count);
        Assert.True(takenCards.Exists(x => x is { Suit: Suit.Spades, Value: Value.Ace }));
        Assert.True(takenCards.Exists(x => x is { Suit: Suit.Hearts, Value: Value.Two }));
        Assert.True(takenCards.Exists(x => x is { Suit: Suit.Diamonds, Value: Value.Three }));

        Assert.Equal(0, _pile.CountCards());
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ShouldDetectMatchOnLast2CardsAdded(bool expectedMatch)
    {
        //Given
        var card1 = new Card(Suit.Spades, Value.Ace);
        var card2 = new Card(Suit.Hearts, Value.Two);
        var card3 = new Card(Suit.Diamonds, Value.Three);

        _matcher.Setup(x => x.IsMatch(card2, card3)).Returns(expectedMatch);

        //When
        _pile.AddCard(card1);
        _pile.AddCard(card2);

        var isMatch = _pile.AddCard(card3);
        
        //Then
        Assert.Equal(expectedMatch, isMatch);
    }
}