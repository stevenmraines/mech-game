namespace RainesGames.Common.States
{
    public interface ISimpleStateManager
    {
        void TransitionToState(IState state);
    }
}