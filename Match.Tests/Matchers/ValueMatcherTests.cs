using Match.Cards;
using Match.Matchers;
using Xunit;

namespace Match.Tests.Matchers;

public class ValueMatcherTests
{
    [Theory]
    [InlineData(Suit.Clubs, Value.Ace, Suit.Clubs, Value.Ace, true)]
    [InlineData(Suit.Clubs, Value.Ace, Suit.Hearts, Value.Ace, true)]
    [InlineData(Suit.Clubs, Value.Ace, Suit.Clubs, Value.Two, false)]
    public void ShouldMatchOnValue(Suit card1Suit, Value card1Value, Suit card2Suit, Value card2Value, bool shouldMatch)
    {
        //Given
        var matcher = new ValueMatcher();

        //When
        var card1 = new Card(card1Suit, card1Value);
        var card2 = new Card(card2Suit, card2Value);

        var isMatch = matcher.IsMatch(card1, card2);

        //Then
        Assert.Equal(shouldMatch, isMatch);
    }
}