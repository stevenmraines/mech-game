namespace RainesGames.Common.States
{
    public abstract class StateEventDispatcher<TState> where TState : State
    {
        protected StateManager<TState> _manager;

        public StateEventDispatcher(StateManager<TState> manager)
        {
            _manager = manager;
        }

        public abstract void DeregisterEventHandlers();
        public abstract void RegisterEventHandlers();
    }
}