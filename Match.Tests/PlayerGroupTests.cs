using Match.Cards;
using Match.Players;
using Xunit;

namespace Match.Tests;

public class PlayerGroupTests
{
    [Fact]
    public void ShouldDetectWin()
    {
        //Given
        var player1 = new Player("a");
        var player2 = new Player("b");
        var playerGroup = new PlayerGroup(player1, player2);

        //When
        player1.TakeCards(new List<Card>
        {
            new Card(Suit.Clubs,Value.Ace),
            new Card(Suit.Clubs,Value.Two),
            new Card(Suit.Clubs,Value.Three),
            new Card(Suit.Clubs,Value.Four)
        });

        player2.TakeCards(new List<Card>
        {
            new Card(Suit.Hearts,Value.Ace),
            new Card(Suit.Hearts,Value.Two),
            new Card(Suit.Hearts,Value.Three),
            new Card(Suit.Hearts,Value.Four),
            new Card(Suit.Hearts,Value.Five),
            new Card(Suit.Hearts,Value.Six),
        });

        player1.TakeCards(new List<Card>
        {
            new Card(Suit.Clubs,Value.Five),
            new Card(Suit.Clubs,Value.Six),
            new Card(Suit.Clubs,Value.Seven)
        });

        //Then
        Assert.Equal(GameOutcome.Winner, playerGroup.GameOutcome);

    }

    [Fact]
    public void ShouldReturnWinner()
    {
        //Given
        var player1 = new Player("a");
        var player2 = new Player("b");
        var playerGroup = new PlayerGroup(player1, player2);

        //When
        player1.TakeCards(new List<Card>
        {
            new Card(Suit.Clubs,Value.Ace),
            new Card(Suit.Clubs,Value.Two),
            new Card(Suit.Clubs,Value.Three),
            new Card(Suit.Clubs,Value.Four)
        });

        player2.TakeCards(new List<Card>
        {
            new Card(Suit.Hearts,Value.Ace),
            new Card(Suit.Hearts,Value.Two),
            new Card(Suit.Hearts,Value.Three),
            new Card(Suit.Hearts,Value.Four),
            new Card(Suit.Hearts,Value.Five),
            new Card(Suit.Hearts,Value.Six),
        });

        player1.TakeCards(new List<Card>
        {
            new Card(Suit.Clubs,Value.Five),
            new Card(Suit.Clubs,Value.Six),
            new Card(Suit.Clubs,Value.Seven)
        });

        //Then
        Assert.Equal("a", playerGroup.Winner.Name);

    }

    [Fact]
    public void ShouldDetectDraw()
    {
        //Given
        var player1 = new Player("a");
        var player2 = new Player("b");
        var playerGroup = new PlayerGroup(player1, player2);

        //When
        player1.TakeCards(new List<Card>
        {
            new Card(Suit.Clubs,Value.Ace),
            new Card(Suit.Clubs,Value.Two),
            new Card(Suit.Clubs,Value.Three),
            new Card(Suit.Clubs,Value.Four)
        });

        player2.TakeCards(new List<Card>
        {
            new Card(Suit.Hearts,Value.Ace),
            new Card(Suit.Hearts,Value.Two),
            new Card(Suit.Hearts,Value.Three),
            new Card(Suit.Hearts,Value.Four),
            new Card(Suit.Hearts,Value.Five),
            new Card(Suit.Hearts,Value.Six),
            new Card(Suit.Hearts,Value.Seven),
        });

        player1.TakeCards(new List<Card>
        {
            new Card(Suit.Clubs,Value.Five),
            new Card(Suit.Clubs,Value.Six),
            new Card(Suit.Clubs,Value.Seven)
        });

        //Then
        Assert.Equal(GameOutcome.Draw, playerGroup.GameOutcome);

    }
}