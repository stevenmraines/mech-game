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
    public class CombatStateManager : MonoBehaviour, IGraphStateManager
    {
        private BattleStartState _battleStart;
        public BattleStartState BattleStart => _battleStart;

        private EnemyPlacementState _enemyPlacement;
        public EnemyPlacementState EnemyPlacement => _enemyPlacement;

        private EnemyTurnState _enemyTurn;
        public EnemyTurnState EnemyTurn => _enemyTurn;

        private PlayerLostState _playerLost;
        public PlayerLostState PlayerLost => _playerLost;

        private PlayerPlacementState _playerPlacement;
        public PlayerPlacementState PlayerPlacement => _playerPlacement;

        private PlayerTurnState _playerTurn;
        public PlayerTurnState PlayerTurn => _playerTurn;

        private PlayerWonState _playerWon;
        public PlayerWonState PlayerWon => _playerWon;

        private ACombatState _currentState;
        public ACombatState CurrentState => _currentState;

        private PreemptiveStrikeGraph _stateGraph;

        private CellEventDispatcher _cellEventDispatcher;
        private UnitEventDispatcher _unitEventDispatcher;

        public void AttemptTransition()
        {
            IState nextState = _stateGraph.GetNextState();

            // Game over state
            if(nextState == null)
                return;

            TransitionToState((ACombatState)nextState);
        }

        void Awake()
        {
            _battleStart = GetComponent<BattleStartState>();
            _enemyPlacement = GetComponent<EnemyPlacementState>();
            _enemyTurn = GetComponent<EnemyTurnState>();
            _playerLost = GetComponent<PlayerLostState>();
            _playerPlacement = GetComponent<PlayerPlacementState>();
            _playerTurn = GetComponent<PlayerTurnState>();
            _playerWon = GetComponent<PlayerWonState>();

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

        void TransitionToState(ACombatState state)
        {
            if(_currentState != null)
                _currentState.ExitState();

            _currentState = state;
            _currentState.EnterState();
        }

        void Update()
        {
            if(!_currentState.Entered)
                return;

            _currentState.UpdateState();

            // TODO this will likely need to be triggered by an event once the game is more built out, leave here for now
            if(_currentState != BattleStart && _currentState != EnemyPlacement && _currentState != PlayerPlacement)
                AttemptTransition();
        }
    }
}