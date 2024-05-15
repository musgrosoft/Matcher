using Match.Cards;
using Match.Matchers;
using Xunit;

namespace Match.Tests.Matchers;

public class SuitAndValueMatcherTests
{
    [Theory]
    [InlineData(Suit.Spades, Value.Jack, Suit.Spades, Value.Jack, true)]
    [InlineData(Suit.Clubs, Value.Queen, Suit.Hearts, Value.Queen, false)]
    [InlineData(Suit.Diamonds, Value.Three, Suit.Diamonds, Value.Four, false)]
    public void ShouldMatchOnSuit(Suit card1Suit, Value card1Value, Suit card2Suit, Value card2Value, bool shouldMatch)
    {
        //Given
        var matcher = new SuitAndValueMatcher();

        //When
        var card1 = new Card(card1Suit, card1Value);
        var card2 = new Card(card2Suit, card2Value);

        var isMatch = matcher.IsMatch(card1, card2);

        //Then
        Assert.Equal(shouldMatch, isMatch);
    }
}