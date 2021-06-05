using RainesGames.Units.States.Idle;
using RainesGames.Units.States.Move;
using UnityEngine;

namespace RainesGames.Units.States
{
    public class UnitStateManager : MonoBehaviour
    {
        private IdleState _idle;
        public IdleState Idle => _idle;

        private MoveState _move;
        public MoveState Move => _move;

        private AUnitState _currentState;
        public AUnitState CurrentState => _currentState;

        private UnitController _controller;
        public UnitController Controller => _controller;

        private CellEventRouter _cellEventRouter;
        private UnitEventRouter _unitEventRouter;

        void Awake()
        {
            _controller = GetComponent<UnitController>();

            _idle = new IdleState(this);
            _move = new MoveState(this);

            TransitionToState(_move);

            _cellEventRouter = new CellEventRouter(this);
            _unitEventRouter = new UnitEventRouter(this);
        }

        void OnDisable()
        {
            _cellEventRouter.DeregisterEventHandlers();
            _unitEventRouter.DeregisterEventHandlers();
        }

        void OnEnable()
        {
            _cellEventRouter.RegisterEventHandlers();
            _unitEventRouter.RegisterEventHandlers();
        }

        // TODO Set units to Idle on state change
        public void TransitionToState(AUnitState state)
        {
            if(_currentState != null)
            {
                if(!state.CanEnterState())
                    return;

                _currentState.ExitState();
            }

            _currentState = state;
            _currentState.EnterState();
        }

        void Update()
        {
            if(!_currentState.Entered)
                return;

            _currentState.UpdateState();
        }
    }
}