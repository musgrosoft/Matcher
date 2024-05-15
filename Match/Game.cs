using Match.Cards;
using Match.Players;
using Match.Utils;

namespace Match;

public class Game(IDeck deck, IPlayerGroup playerGroup, IPile pile, ILogger logger)
{
    public void Play()
    {
        LogStart();

        while (deck.HasMoreCards())
        {
            var card = deck.Take();
            
            var isMatch = pile.AddCard(card);
            
            if (isMatch)
            {
                GivePileToFirstPlayerToSayMatch();
            }
        }

        LogFinish();
    }

    private void LogStart()
    {
        logger.WriteLine("");
        logger.WriteLine("Game is starting");
    }
    
    private void GivePileToFirstPlayerToSayMatch()
    {
        var firstPlayerToSayMatch = playerGroup.FirstPlayerToSayMatch();

        var pileCards = pile.TakeAllCards();

        firstPlayerToSayMatch.TakeCards(pileCards);

        logger.WriteLine();
        logger.WriteLine($"*** {firstPlayerToSayMatch.Name} declares 'Match!' first and picks up {pileCards.Count} cards.");
        logger.WriteLine();
    }

    private void LogFinish()
    {
        logger.WriteLine();
        logger.WriteLine("Game has finished");
        logger.WriteLine();
        logger.WriteLine($"{playerGroup.Player1.Name} has {playerGroup.Player1.TotalCards()} cards.");
        logger.WriteLine($"{playerGroup.Player2.Name} has {playerGroup.Player2.TotalCards()} cards.");
        logger.WriteLine($"Cards left in pile {pile.CountCards()}");
        logger.WriteLine();

        if (playerGroup.GameOutcome == GameOutcome.Draw)
        {
            logger.WriteLine($"*** GAME WAS A DRAW.");
        }
        else if (playerGroup.GameOutcome == GameOutcome.Winner)
        {
            logger.WriteLine($"*** {playerGroup.Winner.Name} WON THE GAME");
        }
    }
    
}