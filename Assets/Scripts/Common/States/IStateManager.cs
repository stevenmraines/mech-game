namespace RainesGames.Common.States
{
    public interface IStateManager
    {
        State CurrentState { get; }
        void NextState();
        void TransitionToState(State state);
    }
}