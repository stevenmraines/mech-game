using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Common.Power;
using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.Underclock;
using RainesGames.Units.Power;
using RainesGames.Units.States;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace RainesGames.Units
{
    public class UnitController : MonoBehaviour, IAbilityPoints, IAbilityPointsConfig
    {
        private AbilityPointsManager _abilityPointsManager;
        public AbilityPointsManager AbilityPointsManager => _abilityPointsManager;
        
        private FactoryResetStatusManager _factoryResetStatusManager;
        public FactoryResetStatusManager FactoryResetStatusManager => _factoryResetStatusManager;
        
        private HackStatusManager _hackStatusManager;
        public HackStatusManager HackStatusManager => _hackStatusManager;
        
        private UnitPositionManager _positionManager;
        public UnitPositionManager PositionManager => _positionManager;
        
        private PowerManager _powerManager;
        public PowerManager PowerManager => _powerManager;
        
        private UnitStateManager _stateManager;
        public UnitStateManager StateManager => _stateManager;
        
        private UnderclockStatusManager _underclockStatusManager;
        public UnderclockStatusManager UnderclockStatusManager => _underclockStatusManager;
        
        private Animator _animator;
        public Animator Animator => _animator;

        private IUnitState _currentState;
        public IUnitState CurrentState { get => _currentState; set => _currentState = value; }

        private NavMeshAgent _navMeshAgent;
        public NavMeshAgent NavMeshAgent => _navMeshAgent;

        private int _baseMovement = 6;

        private int _abilityPoints;
        public int AbilityPoints { get => _abilityPoints; set => _abilityPoints = value; }

        private bool _firstAbilitySpent = false;
        public bool FirstAbilitySpent { get => _firstAbilitySpent; set => _firstAbilitySpent = value; }

        private int _startOfTurnAbilityPoints = 2;
        public int StartOfTurnAbilityPoints => _startOfTurnAbilityPoints;

        void Awake()
        {
            _factoryResetStatusManager = new FactoryResetStatusManager(this);
            _hackStatusManager = new HackStatusManager(this);
            _underclockStatusManager = new UnderclockStatusManager(this);
            _positionManager = new UnitPositionManager(this);
            _powerManager = new PowerManager(this);
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _abilityPointsManager = FindObjectOfType<AbilityPointsManager>();
            _stateManager = FindObjectOfType<UnitStateManager>();
        }

        public bool CurrentStateIs(Type stateType)
        {
            return _currentState.GetType() == stateType;
        }

        public T GetAbility<T>() where T : AbsAbility
        {
            return GetComponent<T>();
        }

        public AbsAbility[] GetAbilities(bool filterShowInTray = true)
        {
            AbsAbility[] abilities = gameObject.GetComponents<AbsAbility>();

            if(!filterShowInTray)
                return abilities;

            List<AbsAbility> filteredAbilities = new List<AbsAbility>();

            foreach(AbsAbility ability in abilities)
            {
                if(ability.ShowInTray)
                    filteredAbilities.Add(ability);
            }

            return filteredAbilities.ToArray();
        }

        public int GetMovement()
        {
            return _baseMovement;
        }

        public AbsAbility[] GetPoweredAbilities()
        {
            AbsAbility[] abilities = gameObject.GetComponents<AbsAbility>();
            return abilities.Where(ability => ability is IPowerContainerInteractable).ToArray();
        }

        public bool HasAbility<T>() where T : AbsAbility
        {
            return GetAbility<T>() != null;
        }

        public bool HasEnemyTag()
        {
            return HasTag(AllUnitsManager.ENEMY_TAG);
        }

        public bool HasPlayerTag()
        {
            return HasTag(AllUnitsManager.PLAYER_TAG);
        }

        public bool HasTag(string tag)
        {
            return gameObject.CompareTag(tag);
        }

        public bool IsEnemy()
        {
            return !IsPlayer();
        }

        public bool IsFactoryReset()
        {
            return _factoryResetStatusManager.Active;
        }

        public bool IsHacked()
        {
            return _hackStatusManager.Active;
        }

        public bool IsPlayer()
        {
            return (HasPlayerTag() && !IsHacked()) || (HasEnemyTag() && IsHacked());
        }

        public bool IsUnderclocked()
        {
            return _underclockStatusManager.Active;
        }

        void OnAbilityPointsChange(UnitController unit)
        {
            // TODO Make _abilityPointsManager, _stateManager, etc. serialized fields and give these components to EVERY unit, to avoid this check
            if(unit == this)
                _stateManager.TransitionToState(this);
        }

        void OnDisable()
        {
            _abilityPointsManager.OnAbilityPointsDecrement -= OnAbilityPointsChange;
            _abilityPointsManager.OnAbilityPointsIncrement -= OnAbilityPointsChange;
            EnemyTurnState.OnEnterState -= OnEnterStateEnemyTurn;
            PlayerTurnState.OnEnterState -= OnEnterStatePlayerTurn;
        }

        void OnEnable()
        {
            _abilityPointsManager.OnAbilityPointsDecrement += OnAbilityPointsChange;
            _abilityPointsManager.OnAbilityPointsIncrement += OnAbilityPointsChange;
            EnemyTurnState.OnEnterState += OnEnterStateEnemyTurn;
            PlayerTurnState.OnEnterState += OnEnterStatePlayerTurn;
        }

        void OnEnterStateEnemyTurn()
        {
            if(IsEnemy())
                Reset();
        }

        void OnEnterStatePlayerTurn()
        {
            if(IsPlayer())
                Reset();
        }

        void Reset()
        {
            _abilityPointsManager.ResetAbilityPoints(this);
            _stateManager.TransitionToState(this);
        }

        public bool SameTagAs(UnitController unit)
        {
            return HasTag(unit.gameObject.tag);
        }

        public bool SameTeamAs(UnitController unit)
        {
            return (IsPlayer() && unit.IsPlayer()) || (IsEnemy() && unit.IsEnemy());
        }

        void Start()
        {
            Reset();
        }
    }
}