using UnityEngine;

public class CombatStateManager : StateManager
{
    [SerializeField] public CombatEnemyPlacementState EnemyPlacementState;
    [SerializeField] public CombatEnemyTurnState EnemyTurnState;
    [SerializeField] public CombatPlayerLostState PlayerLostState;
    [SerializeField] public CombatPlayerPlacementState PlayerPlacementState;
    [SerializeField] public CombatPlayerTurnState PlayerTurnState;
    [SerializeField] public CombatPlayerWonState PlayerWonState;
    [SerializeField] public CombatStartState StartState;

    private CombatStateCellEventDispatcher _cellEventDispatcher;
    private CombatStateUnitEventDispatcher _unitEventDispatcher;

    void Awake()
    {
        _cellEventDispatcher = new CombatStateCellEventDispatcher(this);
        _unitEventDispatcher = new CombatStateUnitEventDispatcher(this);
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
