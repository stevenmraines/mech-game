using UnityEngine;

namespace RainesGames.Common.States
{
    public abstract class StateManager<TState> : MonoBehaviour where TState : State
    {
        protected TState _current;
        public TState CurrentState => _current;

        public virtual void TransitionToState(TState state)
        {
            if(_current != null)
                _current.ExitState();

            _current = state;
            _current.EnterState();
        }

        protected virtual void Update()
        {
            if(!_current.Entered)
                return;

            _current.UpdateState();
        }
    }
}