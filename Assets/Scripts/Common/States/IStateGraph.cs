namespace RainesGames.Common.States
{
    public interface IStateGraph
    {
        IState GetNextState();
    }
}