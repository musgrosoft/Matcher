namespace Match.Players;

//currently only handles 2 players

public class PlayerGroup(IPlayer player1, IPlayer player2) : IPlayerGroup
{
    private static readonly Random Rnd = new();

    public IPlayer Player1 { get; } = player1;
    public IPlayer Player2 { get; } = player2;

    public GameOutcome GameOutcome
    {
        get
        {
            if (Player1.TotalCards() == Player2.TotalCards())
            {
                return GameOutcome.Draw;
            }

            return GameOutcome.Winner;
        }
    }

    public IPlayer Winner
    {
        get
        {
            if (Player1.TotalCards() > Player2.TotalCards())
            {
                return Player1;
            }
            if (Player2.TotalCards() > Player1.TotalCards())
            {
                return Player2;
            }

            return null;
        }
    }

    public IPlayer FirstPlayerToSayMatch()
    {
        int r = Rnd.Next(2);

        return r == 0 ? player1 : player2;
    }
}