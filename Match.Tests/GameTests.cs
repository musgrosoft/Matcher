using Match.Cards;
using Match.Matchers;
using Match.Players;
using Match.Utils;
using Moq;
using Xunit;

namespace Match.Tests;

public class GameTests
{
    private readonly Mock<ILogger> _logger;
    private readonly Mock<IPlayerGroup> _playerGroup;

    public GameTests()
    {
        _logger = new Mock<ILogger>();
        _playerGroup = new Mock<IPlayerGroup>();
        _playerGroup.Setup(x => x.Player1).Returns(new Player("a"));
        _playerGroup.Setup(x => x.Player2).Returns(new Player("b"));
    }

    [Fact]
    public void Should_Take_All_Cards_From_Deck_And_Add_To_Pile_When_Game_Is_Played()
    {
        //Given
        var matcher = new Mock<IMatcher>();
        matcher.Setup(x => x.IsMatch(It.IsAny<Card>(), It.IsAny<Card>())).Returns(false);

        //real pile
        var pile = new Pile(matcher.Object, _logger.Object);

        //real deck
        var deck = new Deck();

        var deckCards = new List<Card>
        {
            new Card(Suit.Clubs, Value.Ace),
            new Card(Suit.Clubs, Value.Two),
            new Card(Suit.Clubs, Value.Three),
            new Card(Suit.Clubs, Value.Four),
        };

        deck.AddCardsToBottom(deckCards);

        var game = new Game(deck, _playerGroup.Object, pile, _logger.Object);

        //When
        game.Play();

        var pileCards = pile.TakeAllCards();

        //Then
        Assert.False(deck.HasMoreCards());
        Assert.Equivalent(deckCards, pileCards);
    }

    [Fact]
    public void Should_Take_Cards_From_Pile_And_Give_To_First_Player_To_Shout_Match_When_There_Is_A_Match()
    {
        //Given
        var firstPlayer = new Mock<IPlayer>();
        var pile = new Mock<IPile>();

        _playerGroup.Setup(x => x.FirstPlayerToSayMatch()).Returns(firstPlayer.Object);
        pile.Setup(x => x.AddCard(It.IsAny<Card>())).Returns(true);

        var pileCards = new List<Card>
        {
            new Card(Suit.Diamonds, Value.Jack),
            new Card(Suit.Diamonds, Value.Queen)
        };

        pile.Setup(x => x.TakeAllCards()).Returns(pileCards);

        var deck = new Deck();
        
        deck.AddCardsToBottom(new List<Card>
        {
            new Card(Suit.Clubs, Value.Ace)
        });

        var game = new Game(deck, _playerGroup.Object, pile.Object, _logger.Object);

        //When
        game.Play();

        //Then
        firstPlayer.Verify(x=>x.TakeCards(pileCards));
    }

    [Theory]
    [InlineData(GameOutcome.Draw, "*** GAME WAS A DRAW.")]
    [InlineData(GameOutcome.Winner, "*** Bert WON THE GAME")]
    public void ShouldOutputResultOfGame(GameOutcome gameOutcome, string expectedLogMessage)
    {
        //Given
        var deck = new Deck();
        var pile = new Mock<IPile>();

        var game = new Game(deck, _playerGroup.Object, pile.Object, _logger.Object);
        
        _playerGroup.Setup(x => x.GameOutcome).Returns(gameOutcome);
        _playerGroup.Setup(x => x.Winner).Returns(new Player("Bert"));

        //When
        game.Play();

        //Then
        _logger.Verify(x=>x.WriteLine(expectedLogMessage));
    }
}

