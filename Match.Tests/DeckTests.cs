using Match.Cards;
using Xunit;

namespace Match.Tests;

public class DeckTests
{
    [Fact]
    public void ShouldReturnCardsThatAreAdded()
    {
        //Given
        var deck = new Deck();

        var card1 = new Card(Suit.Clubs,Value.Four);
        var card2 = new Card(Suit.Hearts, Value.Five);
        var card3 = new Card(Suit.Spades, Value.Jack);
        var card4 = new Card(Suit.Diamonds, Value.Three);
        var card5 = new Card(Suit.Clubs, Value.King);

        var list1 = new List<Card> { card1,card2,card3 };
        var list2 = new List<Card> { card4, card5 };

        deck.AddCardsToBottom(list1);
        deck.AddCardsToBottom(list2);

        //When
        var receivedCard1 = deck.Take();
        var receivedCard2 = deck.Take();
        var receivedCard3 = deck.Take();
        var receivedCard4 = deck.Take();
        var receivedCard5 = deck.Take();

        //Then
        Assert.Equal(card1, receivedCard1);
        Assert.Equal(card2, receivedCard2);
        Assert.Equal(card3, receivedCard3);
        Assert.Equal(card4, receivedCard4);
        Assert.Equal(card5, receivedCard5);

    }

    [Fact]
    public void ShouldReportIfItContainsMoreCards()
    {
        //Given
        var deck = new Deck();

        var card1 = new Card(Suit.Clubs, Value.Four);
        var card2 = new Card(Suit.Hearts, Value.Five);
        var card3 = new Card(Suit.Spades, Value.Jack);
        var card4 = new Card(Suit.Diamonds, Value.Three);
        var card5 = new Card(Suit.Clubs, Value.King);

        var list1 = new List<Card> { card1, card2, card3 };
        var list2 = new List<Card> { card4, card5 };

        deck.AddCardsToBottom(list1);
        deck.AddCardsToBottom(list2);

        //When //Then
        Assert.True(deck.HasMoreCards());

        var receivedCard1 = deck.Take();
        Assert.True(deck.HasMoreCards());

        var receivedCard2 = deck.Take();
        Assert.True(deck.HasMoreCards());

        var receivedCard3 = deck.Take();
        Assert.True(deck.HasMoreCards());

        var receivedCard4 = deck.Take();
        Assert.True(deck.HasMoreCards());

        var receivedCard5 = deck.Take();
        Assert.False(deck.HasMoreCards());


    }
}