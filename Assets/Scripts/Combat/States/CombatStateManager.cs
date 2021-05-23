using RainesGames.Combat.States.BattleStart;
using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Common.States;
using UnityEngine;

namespace RainesGames.Combat.States
{
    public class CombatStateManager : StateManager<CombatState>
    {
        [SerializeField] public BattleStartState BattleStart;
        [SerializeField] public PlayerPlacementState PlayerPlacement;
        [SerializeField] public EnemyPlacementState EnemyPlacement;
        [SerializeField] public PlayerTurnState PlayerTurn;

        private CellEventDispatcher _cellEventDispatcher;
        private UnitEventDispatcher _unitEventDispatcher;

        void Awake()
        {
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
             * happening when CombatStartState Awake is called after EnterState.
             */
            TransitionToState(BattleStart);
        }
    }
}