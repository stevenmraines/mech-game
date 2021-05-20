using UnityEngine;

namespace RainesGames.Combat.States
{
    public class StateManager : Common.States.StateManager
    {
        [SerializeField] public EnemyPlacementState EnemyPlacementState;
        [SerializeField] public EnemyTurnState EnemyTurnState;
        [SerializeField] public PlayerLostState PlayerLostState;
        [SerializeField] public PlayerPlacementState PlayerPlacementState;
        [SerializeField] public PlayerTurnState PlayerTurnState;
        [SerializeField] public PlayerWonState PlayerWonState;
        [SerializeField] public StartState StartState;

        private CellEventDispatcher _cellEventDispatcher;
        private UnitEventDispatcher _unitEventDispatcher;

        void Awake()
        {
            _cellEventDispatcher = new CellEventDispatcher(this);
            _unitEventDispatcher = new UnitEventDispatcher(this);
        }

        public override void NextState()
        {

        }

        void OnDisable()
        {
            _cellEventDispatcher.DeregisterEventHandlers();
            _unitEventDispatcher.DeregisterEventHandlers();
        }

        void OnEnable()
        {
            _cellEventDispatcher.RegisterEventHandlers();
            _unitEventDispatcher.RegisterEventHandlers();
        }

        void Start()
        {
            /*
             * Move this to Start instead of Awake because there's a race condition
             * happening when CombatStartState Awake is called after EnterState.
             */
            TransitionToState(StartState);
        }
    }
}