using RainesGames.Units.States.FactoryReset;
using RainesGames.Units.States.Hack;
using RainesGames.Units.States.Move;
using RainesGames.Units.States.NoAbilityPoints;
using RainesGames.Units.States.Overclock;
using RainesGames.Units.States.ReroutePower;
using RainesGames.Units.States.Underclock;
using UnityEngine;

namespace RainesGames.Units.States
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(FactoryResetState))]
    [RequireComponent(typeof(HackState))]
    [RequireComponent(typeof(MoveState))]
    [RequireComponent(typeof(NoAbilityPointsState))]
    [RequireComponent(typeof(OverclockState))]
    [RequireComponent(typeof(ReroutePowerState))]
    [RequireComponent(typeof(UnderclockState))]
    public class UnitStateManager : MonoBehaviour
    {
        private FactoryResetState _factoryReset;
        public FactoryResetState FactoryReset => _factoryReset;

        private HackState _hack;
        public HackState Hack => _hack;

        private MoveState _move;
        public MoveState Move => _move;

        private NoAbilityPointsState _noAbilityPoints;
        public NoAbilityPointsState NoAbilityPoints => _noAbilityPoints;

        private OverclockState _overclock;
        public OverclockState Overclock => _overclock;

        private ReroutePowerState _reroutePower;
        public ReroutePowerState ReroutePower => _reroutePower;

        private UnderclockState _underclock;
        public UnderclockState Underclock => _underclock;

        void Awake()
        {
            _factoryReset = GetComponent<FactoryResetState>();
            _hack = GetComponent<HackState>();
            _move = GetComponent<MoveState>();
            _noAbilityPoints = GetComponent<NoAbilityPointsState>();
            _overclock = GetComponent<OverclockState>();
            _reroutePower = GetComponent<ReroutePowerState>();
            _underclock = GetComponent<UnderclockState>();
        }

        IUnitState GetFallbackState(UnitController unit)
        {
            if(_move.CanEnterState(unit))
                return _move;

            return _noAbilityPoints;
        }

        void OnDisable()
        {
            
            //_controller.ActionPointsManager.OnAbilityPointsDecrement -= AutoStateChange;
            //_controller.ActionPointsManager.OnAbilityPointsIncrement -= AutoStateChange;
        }

        void OnEnable()
        {
            //EnemyTurnState.OnEnterState += AutoStateChange;
            //PlayerTurnState.OnEnterState += AutoStateChange;
            //_controller.ActionPointsManager.OnAbilityPointsDecrement += AutoStateChange;
            //_controller.ActionPointsManager.OnAbilityPointsIncrement += AutoStateChange;
        }

        public void TransitionToState(UnitController unit, IUnitState state = null)
        {
            if(unit.CurrentState == null || state == null || !state.CanEnterState(unit))
                state = GetFallbackState(unit);

            if(unit.CurrentState == state)
                return;

            if(unit.CurrentState != null)
                unit.CurrentState.ExitState(unit);

            unit.CurrentState = state;
            state.EnterState(unit);
        }
    }
}