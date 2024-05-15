using Match.Cards;
using Match.Players;
using Xunit;

namespace Match.Tests;

public class PlayerTests
{
    [Fact]
    public void ShouldCountNumberOfCardsTaken()
    {
        //Given
        var bert = new Player("bert");

        //When
        bert.TakeCards([new(Suit.Clubs, Value.Ace)]);
        bert.TakeCards([new(Suit.Clubs, Value.Two), new (Suit.Clubs, Value.Three)]);

        //Then
        Assert.Equal(3,bert.TotalCards());
    }
}