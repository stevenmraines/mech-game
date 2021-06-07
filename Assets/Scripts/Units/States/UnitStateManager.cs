using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Units.States.Hack;
using RainesGames.Units.States.Idle;
using RainesGames.Units.States.Move;

namespace RainesGames.Units.States
{
    public class UnitStateManager
    {
        private HackState _hack;
        public HackState Hack => _hack;

        private MoveState _move;
        public MoveState Move => _move;
        
        private NoActionPointsState _noActionPoints;
        public NoActionPointsState NoActionPoints => _noActionPoints;

        private AUnitState _currentState;
        public AUnitState CurrentState => _currentState;

        private UnitController _controller;
        public UnitController Controller => _controller;

        public UnitStateManager(UnitController controller)
        {
            _controller = controller;

            _hack = new HackState(this);
            _move = new MoveState(this);
            _noActionPoints = new NoActionPointsState(this);
            
            AutoStateChange();

            EnemyTurnState.OnEnterState += AutoStateChange;
            PlayerTurnState.OnEnterState += AutoStateChange;
            _controller.ActionPointsManager.OnActionPointsDecrement += AutoStateChange;
        }

        ~UnitStateManager()
        {
            EnemyTurnState.OnEnterState -= AutoStateChange;
            PlayerTurnState.OnEnterState -= AutoStateChange;
            _controller.ActionPointsManager.OnActionPointsDecrement -= AutoStateChange;
        }

        public void AutoStateChange()
        {
            TransitionToState(GetFallbackState());
        }

        AUnitState GetFallbackState()
        {
            AUnitState fallbackState = _move;

            if(!_move.CanEnterState())
                fallbackState = _noActionPoints;

            return fallbackState;
        }

        public void TransitionToState(AUnitState state)
        {
            if(!state.CanEnterState())
                state = GetFallbackState();

            if(_currentState == state)
                return;

            if(_currentState != null)
                _currentState.ExitState();

            _currentState = state;
            _currentState.EnterState();
        }
    }
}