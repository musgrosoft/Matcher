namespace Match.Players;

public interface IPlayerGroup
{
    IPlayer Player1 { get; }
    IPlayer Player2 { get; }
    GameOutcome GameOutcome { get; }
    IPlayer Winner { get; }
    IPlayer FirstPlayerToSayMatch();
}