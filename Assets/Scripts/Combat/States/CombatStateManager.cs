using RainesGames.Combat.States.BattleStart;
using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerLost;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Combat.States.PlayerWon;
using RainesGames.Combat.States.StateGraphs.PreemptiveStrike;
using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Combat.States
{
    [RequireComponent(typeof(BattleStartState))]
    [RequireComponent(typeof(EnemyPlacementState))]
    [RequireComponent(typeof(EnemyTurnState))]
    [RequireComponent(typeof(PlayerLostState))]
    [RequireComponent(typeof(PlayerPlacementState))]
    [RequireComponent(typeof(PlayerTurnState))]
    [RequireComponent(typeof(PlayerWonState))]
    public class CombatStateManager : StateManager<CombatState>
    {
        [HideInInspector] public BattleStartState BattleStart;
        [HideInInspector] public EnemyPlacementState EnemyPlacement;
        [HideInInspector] public EnemyTurnState EnemyTurn;
        [HideInInspector] public PlayerLostState PlayerLost;
        [HideInInspector] public PlayerPlacementState PlayerPlacement;
        [HideInInspector] public PlayerTurnState PlayerTurn;
        [HideInInspector] public PlayerWonState PlayerWon;

        private PreemptiveStrikeGraph _stateGraph;

        private CellEventDispatcher _cellEventDispatcher;
        private UnitEventDispatcher _unitEventDispatcher;

        public void AttemptTransition()
        {
            CombatState nextState = _stateGraph.GetNextState();

            // Game over state
            if(nextState == null)
                return;

            TransitionToState(nextState);
        }

        void Awake()
        {
            BattleStart = GetComponent<BattleStartState>();
            EnemyPlacement = GetComponent<EnemyPlacementState>();
            EnemyTurn = GetComponent<EnemyTurnState>();
            PlayerLost = GetComponent<PlayerLostState>();
            PlayerPlacement = GetComponent<PlayerPlacementState>();
            PlayerTurn = GetComponent<PlayerTurnState>();
            PlayerWon = GetComponent<PlayerWonState>();

            _stateGraph = new PreemptiveStrikeGraph(this);
            _cellEventDispatcher = new CellEventDispatcher(this);
            _unitEventDispatcher = new UnitEventDispatcher(this);
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
             * happening when CombatStartState Awake is called after its EnterState.
             */
            AttemptTransition();
        }

        protected override void Update()
        {
            base.Update();

            // TODO this will likely need to be triggered by an event once the game is more built out, leave here for now
            if(_current != BattleStart && _current != EnemyPlacement && _current != PlayerPlacement)
                AttemptTransition();
        }
    }
}