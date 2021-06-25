namespace RainesGames.Common.States
{
    public interface IStateUpdateable : IState
    {
        bool Entered { get; }
        void UpdateState();
    }
}