using RainesGames.Combat.States;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Common.Power;
using RainesGames.Units.Mechs.Classes;
using RainesGames.Units.Mechs.MechParts;
using RainesGames.Units.Mechs.States;
using RainesGames.Units.Selection;
using RainesGames.Units.States;
using RainesGames.Units.Usables.Abilities;
using TGS;
using UnityEngine;
using UnityEngine.AI;

namespace RainesGames.Units.Mechs
{
    [RequireComponent(typeof(AbsMechClass))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Head))]
    [RequireComponent(typeof(LeftArm))]
    [RequireComponent(typeof(Legs))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(RightArm))]
    [RequireComponent(typeof(Torso))]
    [DisallowMultipleComponent]
    public sealed class MechController : AbsUnit
    {
        #region INSTANCE VARIABLES
        private StateEventHandlersMap _stateEventHandlers;
        private StateTransitionValidatorMap _transitionValidators;

        private Animator _animator;
        public Animator Animator => _animator;

        private Head _head;
        public Head Head => _head;

        private LeftArm _leftArm;
        public LeftArm LeftArm => _leftArm;

        private Legs _legs;
        public Legs Legs => _legs;

        private AbsMechClass _mechClass;
        public AbsMechClass MechClass => _mechClass;

        private NavMeshAgent _navMeshAgent;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        private RightArm _rightArm;
        public RightArm RightArm => _rightArm;

        private Torso _torso;
        public Torso Torso => _torso;
        #endregion


        #region MONOBEHAVIOUR METHODS
        protected override void Awake()
        {
            base.Awake();

            _stateEventHandlers = new StateEventHandlersMap();
            _transitionValidators = new StateTransitionValidatorMap();

            _animator = GetComponent<Animator>();
            _head = GetComponent<Head>();
            _leftArm = GetComponent<LeftArm>();
            _legs = GetComponent<Legs>();
            _mechClass = GetComponent<AbsMechClass>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _rightArm = GetComponent<RightArm>();
            _torso = GetComponent<Torso>();
            
            _powerManager.SetPower(GetMaxPower());
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

            _actionPointsManager.OnDecrement -= OnActionPointsChange;
            _actionPointsManager.OnForceSpendAll -= OnActionPointsChange;
            _actionPointsManager.OnIncrement -= OnActionPointsChange;
            _actionPointsManager.OnReset -= OnActionPointsChange;

            _factoryResetStatusManager.OnActivate -= ForceSpendAllActionPoints;
            _hackStatusManager.OnActivate -= ForceSpendAllActionPoints;

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

            _actionPointsManager.OnDecrement += OnActionPointsChange;
            _actionPointsManager.OnForceSpendAll += OnActionPointsChange;
            _actionPointsManager.OnIncrement += OnActionPointsChange;
            _actionPointsManager.OnReset += OnActionPointsChange;

            _factoryResetStatusManager.OnActivate += ForceSpendAllActionPoints;
            _hackStatusManager.OnActivate += ForceSpendAllActionPoints;

            _stateManager.OnEnterState += OnEnterState;
            _stateManager.OnExitState += OnExitState;
        }
        #endregion


        #region MISC
        public override int GetMovement()
        {
            return MechClass.GetBaseMovement();
        }

        /*
         * This should respond to both decrement AND increment events,
         * because if a unit is in the noAP state and another unit uses
         * Overclock on them, we want them to transition to Idle/Move.
         */
        void CooldownAbilities()
        {
            foreach(IAbility ability in GetCooldownAbilities())
                ((ICooldownManagerClient)ability).Cooldown();
        }

        void OnActionPointsChange()
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
            {
                ResetActionPointsAndState();
                CooldownAbilities();
            }
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
            {
                ResetActionPointsAndState();
                CooldownAbilities();
            }
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

        void ResetActionPointsAndState()
        {
            if(!IsFactoryReset())
                _actionPointsManager.ResetActionPoints(GetActionPointsResetAmount());
        }
        #endregion

        // TODO All this ability points, unit state, power, etc. manager stuff could be moved to AbsUnit
        #region ACTION POINTS MANAGER
        public override void DecrementActionPoints(int points = 1)
        {
            _actionPointsManager.Decrement(points);
        }

        public override bool FirstActionSpent()
        {
            return _actionPointsManager.FirstActionSpent();
        }

        public override void ForceSpendAllActionPoints()
        {
            _actionPointsManager.ForceSpendAllActionPoints();
        }

        public override int GetActionPoints()
        {
            return _actionPointsManager.GetActionPoints();
        }

        int GetActionPointsResetAmount()
        {
            if(IsUnderclocked())
                return Mathf.Max(0, _mechClass.GetStartOfTurnActionPoints() - 1);  // TODO Make this and overclock stackable?

            return _mechClass.GetStartOfTurnActionPoints();
        }

        public override int GetStartOfTurnActionPoints()
        {
            return _mechClass.GetStartOfTurnActionPoints();
        }

        public override void IncrementActionPoints(int points = 1)
        {
            _actionPointsManager.Increment(points);
        }
        #endregion


        #region ABILITY STATUS MANAGERS
        public override void FactoryReset(int duration)
        {
            _factoryResetStatusManager.Activate(duration);
        }

        public override int GetFactoryResetTurnsRemaining()
        {
            return _factoryResetStatusManager.GetTurnsRemaining();
        }

        public override int GetHackedTurnsRemaining()
        {
            return _hackStatusManager.GetTurnsRemaining();
        }

        public override int GetUnderclockedTurnsRemaining()
        {
            return _underclockStatusManager.GetTurnsRemaining();
        }

        public override void Hack(int duration)
        {
            _hackStatusManager.Activate(duration);
        }

        public override bool IsFactoryReset()
        {
            return _factoryResetStatusManager.IsActive();
        }

        public override bool IsHacked()
        {
            return _hackStatusManager.IsActive();
        }

        public override bool IsUnderclocked()
        {
            return _underclockStatusManager.IsActive();
        }

        public override void Underclock(int duration)
        {
            _underclockStatusManager.Activate(duration);
        }
        #endregion


        #region CELL EVENTS
        public override void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if((Object)UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetCellHandler(GetCurrentState())?.OnCellClick(sender, cellIndex, buttonIndex);
        }

        public override void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            if((Object)UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetCellHandler(GetCurrentState())?.OnCellEnter(sender, cellIndex);
        }

        public override void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            if((Object)UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetCellHandler(GetCurrentState())?.OnCellExit(sender, cellIndex);
        }
        #endregion


        #region POSITION MANAGER
        public override Cell GetPosition()
        {
            return _positionManager.GetPosition();
        }

        public override bool IsPlaced()
        {
            return _positionManager.IsPlaced();
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
            return _mechClass.GetMaxPower();
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
            _powerManager.RevertPowerState(GetMaxPower());
        }

        public override void TransferPowerFrom(IPowerContainerInteractable container, int power = 1)
        {
            _powerManager.TransferPowerFrom(container, power, GetMaxPower());
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
            return _stateManager.GetCurrentState();
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
        public override void OnUnitClick(IUnit unit, int buttonIndex)
        {
            if((Object)UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetUnitHandler(GetCurrentState())?.OnUnitClick(unit, buttonIndex);
        }

        public override void OnUnitEnter(IUnit unit)
        {
            if((Object)UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetUnitHandler(GetCurrentState())?.OnUnitEnter(unit);
        }

        public override void OnUnitExit(IUnit unit)
        {
            if((Object)UnitSelectionManager.ActiveUnit == this)
                _stateEventHandlers.GetUnitHandler(GetCurrentState())?.OnUnitExit(unit);
        }
        #endregion
    }
}