namespace RainesGames.Units.States
{
    public class UnitStateManager
    {
        private UnitState _currentState = UnitState.IDLE;

        public delegate void StateChangeDelegate(UnitState state);
        public event StateChangeDelegate OnEnterState;
        public event StateChangeDelegate OnExitState;

        public UnitState GetCurrentState()
        {
            return _currentState;
        }

        public void TransitionToState(UnitState state)
        {
            if(_currentState == state)
                return;

            OnExitState?.Invoke(_currentState);
            _currentState = state;
            OnEnterState?.Invoke(state);
        }
    }
}