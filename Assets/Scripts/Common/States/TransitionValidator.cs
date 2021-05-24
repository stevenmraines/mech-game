namespace RainesGames.Common.States
{
    public abstract class TransitionValidator<TState> where TState : State
    {
        public abstract bool ValidateTransition(TState state);
    }
}