using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Units.States
{
    public class UnitStateManager : StateManager<UnitState>
    {
        [SerializeField] public IdleState Idle;
        [SerializeField] public ActiveState Active;

        private UnitController _controller;
        public UnitController Controller { get => _controller; }

        void Awake()
        {
            _controller = GetComponent<UnitController>();
        }

        void OnActiveStateEnter(UnitController unit)
        {
            // Can only have one unit active at a time
            if(unit.StateManager != this && _current == Active)
                TransitionToState(Idle);
        }

        void OnDisable()
        {
            ActiveState.OnEnterState -= OnActiveStateEnter;
        }

        void OnEnable()
        {
            ActiveState.OnEnterState += OnActiveStateEnter;
        }

        void Start()
        {
            TransitionToState(Idle);
        }
    }
}