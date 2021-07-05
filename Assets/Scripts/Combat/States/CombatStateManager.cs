using RainesGames.Combat.States.BattleStart;
using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerLost;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Combat.States.PlayerWon;
using RainesGames.Combat.States.StateGraphs.PreemptiveStrike;
using RainesGames.Common.States;
using RainesGames.Units.Usables;
using RainesGames.Units.Usables.Abilities;
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
    public class CombatStateManager : MonoBehaviour
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

        private AbsCombatState _currentState;
        public AbsCombatState CurrentState => _currentState;

        private PreemptiveStrikeGraph _stateGraph;

        private CellEventRouter _cellEventRouter;
        public CellEventRouter CellEventRouter => _cellEventRouter;

        private UnitEventRouter _unitEventRouter;
        public UnitEventRouter UnitEventRouter => _unitEventRouter;

        public void AttemptTransition()
        {
            IState nextState = _stateGraph.GetNextState();

            // Game over state
            if(nextState == null)
                return;

            TransitionToState((AbsCombatState)nextState);
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

            _cellEventRouter = new CellEventRouter(this);
            _unitEventRouter = new UnitEventRouter(this);
        }

        void OnDisable()
        {
            _cellEventRouter.DeregisterEventHandlers();
            _unitEventRouter.DeregisterEventHandlers();
            ActionPointsManager.OnDecrementStatic -= AttemptTransition;
        }

        void OnEnable()
        {
            _cellEventRouter.RegisterEventHandlers();
            _unitEventRouter.RegisterEventHandlers();
            ActionPointsManager.OnDecrementStatic += AttemptTransition;
        }

        void Start()
        {
            AttemptTransition();
        }

        // TODO Should accept an IState or ICombatState interface instead
        void TransitionToState(AbsCombatState state)
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
        }
    }
}