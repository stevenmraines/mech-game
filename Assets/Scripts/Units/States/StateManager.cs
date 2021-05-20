using UnityEngine;

namespace RainesGames.Units.States
{
    public class StateManager : Common.States.StateManager
    {
        [SerializeField] public IdleState IdleState;
        [SerializeField] public ActiveState ActiveState;
        [SerializeField] public DestroyedState DestroyedState;
        [SerializeField] public TargetedState TargetedState;

        private UnitController _controller;
        public UnitController Controller { get => _controller; }

        void Awake()
        {
            _controller = GetComponent<UnitController>();
        }

        public override void NextState()
        {

        }

        void OnActiveStateEnter(UnitController unit)
        {
            // Can only have one unit active at a time
            if(unit.StateManager != this && _current == ActiveState)
                TransitionToState(IdleState);
        }

        void OnDisable()
        {
            ActiveState.OnStateEnter -= OnActiveStateEnter;
        }

        void OnEnable()
        {
            ActiveState.OnStateEnter += OnActiveStateEnter;
        }

        void Start()
        {
            TransitionToState(IdleState);
        }
    }
}