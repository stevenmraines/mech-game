using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Units.States
{
    [RequireComponent(typeof(ActiveState))]
    [RequireComponent(typeof(IdleState))]
    public class UnitStateManager : StateManager<UnitState>
    {
        [HideInInspector] public ActiveState Active;
        [HideInInspector] public IdleState Idle;

        private UnitController _controller;
        public UnitController Controller => _controller;

        void Awake()
        {
            Active = GetComponent<ActiveState>();
            Idle = GetComponent<IdleState>();

            _controller = GetComponent<UnitController>();
        }

        void OnActiveStateEnter(UnitController unit)
        {
            // Can only have one unit active at a time
            if(unit.StateManager != this && _current == Active)
                TransitionToState(Idle);
        }

        void OnCombatStateChange()
        {
            TransitionToState(Idle);
        }

        void OnDisable()
        {
            ActiveState.OnEnterState -= OnActiveStateEnter;

            /*
             * TODO these need to happen with basically every state transition,
             * so some OnCombatStateChange event may be more appropriate.
             * 
             * But of course then Common.States.State.cs TransitionToState method will need to be overridden.
             */
            EnemyPlacementState.OnExitState -= OnCombatStateChange;
            PlayerPlacementState.OnExitState -= OnCombatStateChange;
        }

        void OnEnable()
        {
            ActiveState.OnEnterState += OnActiveStateEnter;
            EnemyPlacementState.OnExitState += OnCombatStateChange;
            PlayerPlacementState.OnExitState += OnCombatStateChange;
        }

        void Start()
        {
            TransitionToState(Idle);
        }
    }
}