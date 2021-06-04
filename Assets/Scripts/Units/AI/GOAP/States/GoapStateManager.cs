using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Units.AI.GOAP.States
{
    [RequireComponent(typeof(IdleState))]
    [RequireComponent(typeof(MoveWithinRangeState))]
    [RequireComponent(typeof(PerformActionState))]
    public class GoapStateManager : MonoBehaviour, ISimpleStateManager
    {
        private IdleState _idle;
        public IdleState Idle => _idle;

        private MoveWithinRangeState _moveWithinRange;
        public MoveWithinRangeState MoveWithinRange => _moveWithinRange;

        private PerformActionState _performAction;
        public PerformActionState PerformAction => _performAction;

        private AGoapState _currentState;
        public AGoapState CurrentState => _currentState;

        void Awake()
        {
            _idle = new IdleState();
            _moveWithinRange = new MoveWithinRangeState();
            _performAction = new PerformActionState();
        }
        
        public void TransitionToState(IState state)
        {
            if(_currentState != null)
                _currentState.ExitState();

            _currentState = (AGoapState)state;
            _currentState.EnterState();
        }
    }
}