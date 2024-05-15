// See https://aka.ms/new-console-template for more information

using Match;
using Match.Cards;
using Match.Matchers;
using Match.Players;
using Match.Utils;

Console.WriteLine("SHALL WE PLAY A GAME?");
Console.WriteLine("");

int numberDecks = 0;
while (numberDecks is <= 0 or > 100)
{
    Console.WriteLine("How many packs to play with (1-100)?");
    int.TryParse(Console.ReadLine(), out numberDecks);
}
Console.WriteLine("");

IMatcher matcher = null;

while (matcher == null)
{
    Console.WriteLine("Which match condition to play with? Suits (S) , Values (V) , Suits & Values SV");
    
    var matchCondition = Console.ReadLine().ToUpper();

    matcher = matchCondition switch
    {
        "S" => new SuitMatcher(),
        "V" => new ValueMatcher(),
        "SV" => new SuitAndValueMatcher(),
        _ => matcher
    };
}

Console.WriteLine("");

var deck = new Deck();

for (int i = 0; i < numberDecks; i++)
{
    var pack = new FullPack();
    deck.AddCardsToBottom(pack.Cards);
}

deck.Shuffle();

var playerGroup = new PlayerGroup(new Player("player1"), new Player("player2"));

var logger = new ConsoleLogger();

var pile = new Pile(matcher, logger);

var game = new Game(deck, playerGroup, pile, logger);

game.Play();
