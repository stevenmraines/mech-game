using RainesGames.Combat.States;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Common.Power;
using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.Mechs.States;
using RainesGames.Units.Position;
using RainesGames.Units.Power;
using RainesGames.Units.Selection;
using RainesGames.Units.States;
using TGS;
using UnityEngine;
using UnityEngine.AI;

namespace RainesGames.Units.Mechs
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    [DisallowMultipleComponent]
    public class MechController : AbsUnit
    {
        #region INSTANCE VARIABLES
        private AbilityPointsManager _abilityPointsManager;
        private FactoryResetStatusManager _factoryResetStatusManager;
        private HackStatusManager _hackStatusManager;
        private PositionManager _positionManager;
        private PowerManager _powerManager;
        private StateEventHandlersMap _stateEventHandlers;
        private UnitStateManager _stateManager;
        private StateTransitionValidatorMap _transitionValidators;
        private UnderclockStatusManager _underclockStatusManager;

        private Animator _animator;
        public Animator Animator => _animator;

        private NavMeshAgent _navMeshAgent;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        private int _baseMovement = 6;
        #endregion


        #region MONOBEHAVIOUR METHODS
        void Awake()
        {
            _stateEventHandlers = new StateEventHandlersMap();
            _transitionValidators = new StateTransitionValidatorMap();

            _abilityPointsManager = FindObjectOfType<AbilityPointsManager>();
            _animator = GetComponent<Animator>();
            _factoryResetStatusManager = GetComponent<FactoryResetStatusManager>();
            _hackStatusManager = GetComponent<HackStatusManager>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _positionManager = GetComponent<PositionManager>();
            _powerManager = GetComponent<PowerManager>();
            _stateManager = GetComponent<UnitStateManager>();
            _underclockStatusManager = GetComponent<UnderclockStatusManager>();
        }

        void OnDisable()
        {
            EnemyTurnState.OnEnterState -= OnEnterStateEnemyTurn;
            EnemyTurnState.OnExitState -= OnExitStateEnemyTurn;
            PlayerTurnState.OnEnterState -= OnEnterStatePlayerTurn;
            PlayerTurnState.OnExitState -= OnExitStatePlayerTurn;

            CellEventRouter.OnCellClickReroute -= OnCellClick;
            CellEventRouter.OnCellEnterReroute -= OnCellEnter;
            CellEventRouter.OnCellExitReroute -= OnCellExit;
            UnitEventRouter.OnUnitClickReroute -= OnUnitClick;
            UnitEventRouter.OnUnitEnterReroute -= OnUnitEnter;
            UnitEventRouter.OnUnitExitReroute -= OnUnitExit;

            _abilityPointsManager.OnDecrement -= OnAbilityPointsChange;
            _abilityPointsManager.OnForceSpendAll -= OnAbilityPointsChange;
            _abilityPointsManager.OnIncrement -= OnAbilityPointsChange;
            _abilityPointsManager.OnReset -= OnAbilityPointsChange;

            _stateManager.OnEnterState -= OnEnterState;
            _stateManager.OnExitState -= OnExitState;
        }

        void OnEnable()
        {
            EnemyTurnState.OnEnterState += OnEnterStateEnemyTurn;
            EnemyTurnState.OnExitState += OnExitStateEnemyTurn;
            PlayerTurnState.OnEnterState += OnEnterStatePlayerTurn;
            PlayerTurnState.OnExitState += OnExitStatePlayerTurn;

            CellEventRouter.OnCellClickReroute += OnCellClick;
            CellEventRouter.OnCellEnterReroute += OnCellEnter;
            CellEventRouter.OnCellExitReroute += OnCellExit;
            UnitEventRouter.OnUnitClickReroute += OnUnitClick;
            UnitEventRouter.OnUnitEnterReroute += OnUnitEnter;
            UnitEventRouter.OnUnitExitReroute += OnUnitExit;

            _abilityPointsManager.OnDecrement += OnAbilityPointsChange;
            _abilityPointsManager.OnForceSpendAll += OnAbilityPointsChange;
            _abilityPointsManager.OnIncrement += OnAbilityPointsChange;
            _abilityPointsManager.OnReset += OnAbilityPointsChange;

            _stateManager.OnEnterState += OnEnterState;
            _stateManager.OnExitState += OnExitState;
        }

        void Start()
        {
            ResetAbilityPointsAndState();
        }
        #endregion


        #region MISC
        public override int GetMovement()
        {
            return _baseMovement;
        }

        /*
         * This should respond to both decrement AND increment events,
         * because if a unit is in the noAP state and another unit uses
         * Overclock on them, we want them to transition to Idle/Move.
         */
        void OnAbilityPointsChange()
        {
            _stateManager.TransitionToState(GetFallbackState());
        }

        void OnEnterState(UnitState state)
        {
            _stateEventHandlers.GetStateChangeHandler(state)?.OnEnterState(this);
        }

        void OnExitState(UnitState state)
        {
            _stateEventHandlers.GetStateChangeHandler(state)?.OnExitState(this);
        }

        void OnEnterStateEnemyTurn()
        {
            if(IsEnemy())
                ResetAbilityPointsAndState();
        }

        void OnExitStateEnemyTurn()
        {
            if(IsEnemy())
            {
                _factoryResetStatusManager.Countdown();
                _underclockStatusManager.Countdown();
            }

            if(HasPlayerTag())
                _hackStatusManager.Countdown();
        }

        void OnEnterStatePlayerTurn()
        {
            if(IsPlayer())
                ResetAbilityPointsAndState();
        }

        void OnExitStatePlayerTurn()
        {
            if(IsPlayer())
            {
                _factoryResetStatusManager.Countdown();
                _underclockStatusManager.Countdown();
            }

            if(HasEnemyTag())
                _hackStatusManager.Countdown();
        }

        void ResetAbilityPointsAndState()
        {
            if(!IsFactoryReset())
                _abilityPointsManager.ResetAbilityPoints(GetAbilityPointsResetAmount());
        }
        #endregion


        #region ABILITY POINTS MANAGER
        public override void DecrementAbilityPoints(int points = 1)
        {
            _abilityPointsManager.Decrement(points);
        }

        public override void ForceSpendAllAbilityPoints()
        {
            _abilityPointsManager.ForceSpendAllAbilityPoints();
        }

        public override int GetAbilityPoints()
        {
            return _abilityPointsManager.AbilityPoints;
        }

        int GetAbilityPointsResetAmount()
        {
            if(IsUnderclocked())
                return Mathf.Max(0, _abilityPointsManager.StartOfTurnAbilityPoints - 1);  // TODO Make this and overclock stackable?

            return _abilityPointsManager.StartOfTurnAbilityPoints;
        }

        public override bool GetFirstAbilitySpent()
        {
            return _abilityPointsManager.FirstAbilitySpent;
        }

        public override int GetStartOfTurnAbilityPoints()
        {
            return _abilityPointsManager.StartOfTurnAbilityPoints;
        }

        public override void IncrementAbilityPoints(int points = 1)
        {
            _abilityPointsManager.Increment(points);
        }
        #endregion


        #region ABILITY STATUS MANAGERS
        public override void FactoryReset()
        {
            _factoryResetStatusManager.Activate();
        }

        public override int GetFactoryResetTurnsRemaining()
        {
            return _factoryResetStatusManager.TurnsRemaining;
        }

        public override int GetHackedTurnsRemaining()
        {
            return _hackStatusManager.TurnsRemaining;
        }

        public override int GetUnderclockedTurnsRemaining()
        {
            return _underclockStatusManager.TurnsRemaining;
        }

        public override void Hack()
        {
            _hackStatusManager.Activate();
        }

        public override bool IsFactoryReset()
        {
            return _factoryResetStatusManager.Active;
        }

        public override bool IsHacked()
        {
            return _hackStatusManager.Active;
        }

        public override bool IsUnderclocked()
        {
            return _underclockStatusManager.Active;
        }

        public override void Underclock()
        {
            _underclockStatusManager.Activate();
        }
        #endregion


        #region CELL EVENTS
        public override void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetCellHandler(GetCurrentState())?.OnCellClick(sender, cellIndex, buttonIndex);
        }

        public override void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            if(UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetCellHandler(GetCurrentState())?.OnCellEnter(sender, cellIndex);
        }

        public override void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            if(UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetCellHandler(GetCurrentState())?.OnCellExit(sender, cellIndex);
        }
        #endregion


        #region POSITION MANAGER
        public override Cell GetPosition()
        {
            return _positionManager.Position;
        }

        public override bool IsPlaced()
        {
            return _positionManager.IsPlaced;
        }

        public override void PlaceOnCell(int cellIndex)
        {
            _positionManager.PlaceOnPosition(gameObject.transform, cellIndex);
        }

        public override void SetCell(int cellIndex)
        {
            _positionManager.SetPosition(cellIndex);
        }
        #endregion


        #region POWER MANAGER
        public override void DiscardPowerState()
        {
            _powerManager.DiscardPowerState();
        }

        public override int GetMaxPower()
        {
            return _powerManager.GetMaxPower();
        }

        public override int GetPower()
        {
            return _powerManager.GetPower();
        }

        public override void RecordPowerState()
        {
            _powerManager.RecordPowerState(GetPoweredAbilities());
        }

        public override void RevertPowerState()
        {
            _powerManager.RevertPowerState();
        }

        public override void TransferPowerFrom(IPowerContainerInteractable container, int power = 1)
        {
            _powerManager.TransferPowerFrom(container, power);
        }

        public override void TransferPowerTo(IPowerContainerInteractable container, int power = 1)
        {
            _powerManager.TransferPowerTo(container, power);
        }
        #endregion


        #region STATE MANAGER
        public override bool CanEnterState(UnitState state)
        {
            IStateTransitionValidator validator = _transitionValidators.GetValidator(state);
            return validator == null || validator.CanEnterState(this);
        }

        public override UnitState GetCurrentState()
        {
            return _stateManager.CurrentState;
        }

        UnitState GetFallbackState()
        {
            bool move = CanEnterState(UnitState.MOVE);
            bool noAP = CanEnterState(UnitState.NO_ABILITY_POINTS);
            return move ? UnitState.MOVE : (noAP ? UnitState.NO_ABILITY_POINTS : UnitState.IDLE);
        }

        public override bool HasCellEventHandler()
        {
            return HasCellEventHandler(GetCurrentState());
        }

        public override bool HasCellEventHandler(UnitState state)
        {
            return _stateEventHandlers.GetCellHandler(state) != null;
        }

        public override bool HasUnitEventHandler()
        {
            return HasUnitEventHandler(GetCurrentState());
        }

        public override bool HasUnitEventHandler(UnitState state)
        {
            return _stateEventHandlers.GetUnitHandler(state) != null;
        }

        public override void TransitionToState(UnitState state)
        {
            if(!CanEnterState(state))
                state = GetFallbackState();

            _stateManager.TransitionToState(state);
        }
        #endregion


        #region UNIT EVENTS
        public override void OnUnitClick(AbsUnit unit, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetUnitHandler(GetCurrentState())?.OnUnitClick(unit, buttonIndex);
        }

        public override void OnUnitEnter(AbsUnit unit)
        {
            if(UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetUnitHandler(GetCurrentState())?.OnUnitEnter(unit);
        }

        public override void OnUnitExit(AbsUnit unit)
        {
            if(UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetUnitHandler(GetCurrentState())?.OnUnitExit(unit);
        }
        #endregion
    }
}