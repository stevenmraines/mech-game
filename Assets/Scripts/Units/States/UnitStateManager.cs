using UnityEngine;

namespace RainesGames.Units.States
{
    [DisallowMultipleComponent]
    public class UnitStateManager : MonoBehaviour
    {
        private UnitState _currentState = UnitState.IDLE;
        public UnitState CurrentState => _currentState;

        public delegate void StateChangeDelegate(UnitState state);
        public event StateChangeDelegate OnEnterState;
        public event StateChangeDelegate OnExitState;

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