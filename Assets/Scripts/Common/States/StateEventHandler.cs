namespace RainesGames.Common.States
{
    public abstract class StateEventHandler<TState> where TState : State
    {
        protected TState _state;

        public StateEventHandler(TState state)
        {
            _state = state;
        }
    }
}