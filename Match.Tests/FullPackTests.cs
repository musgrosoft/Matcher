using Match.Cards;
using Xunit;

namespace Match.Tests
{
    public class FullPackTests
    {
        [Fact]
        public void ShouldHave52CardsInPack()
        {
            //Given //When
            var pack = new FullPack();

            //Then
            Assert.Equal(52,pack.Cards.Count);

        }

        [Fact]
        public void ShouldHave13CardsOfEachSuitInPack()
        {
            //Given //When
            var pack = new FullPack();

            //Then

            Assert.Equal(13, pack.Cards.Count(x => x.Suit == Suit.Clubs));
            Assert.Equal(13, pack.Cards.Count(x => x.Suit == Suit.Hearts));
            Assert.Equal(13, pack.Cards.Count(x => x.Suit == Suit.Spades));
            Assert.Equal(13, pack.Cards.Count(x => x.Suit == Suit.Diamonds));
        }

        [Fact]
        public void ShouldHave4CardsOfEachValueInPack()
        {
            //Given //When
            var pack = new FullPack();

            //Then
            
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Ace));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Two));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Three));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Four));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Five));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Six));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Seven));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Eight));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Nine));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Ten));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Jack));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.Queen));
            Assert.Equal(4, pack.Cards.Count(x => x.Value == Value.King));

        }

        [Fact]
        public void ShouldHaveNoDuplicatesInPack()
        {
            //Given //When
            var pack = new FullPack();

            //Then

            Assert.Equal(52, pack.Cards.DistinctBy(x => new { x.Value , x.Suit}).Count());

        }

    }
}
