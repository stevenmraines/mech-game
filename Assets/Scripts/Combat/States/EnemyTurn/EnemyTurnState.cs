using RainesGames.Grid;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class EnemyTurnState : AbsCombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnEnterState;
        public static event StateTransitionDelegate OnExitState;

        protected override void Awake()
        {
            base.Awake();
            _cellEventHandler = new CellEventHandler(this);
            _unitEventHandler = new UnitEventHandler(this);
            _stateName = "Enemy Turn";
        }

        public override void EnterState()
        {
            base.EnterState();
            OnEnterState?.Invoke();
            GridWrapper.EnableCellHighlight();
            GridWrapper.DisableTerritories();
            StartCoroutine(CombatStateUtilities.NoActionPointsCheck(_manager));
        }

        public override void ExitState()
        {
            base.ExitState();
            OnExitState?.Invoke();
        }

        public override void UpdateState()
        {
            if(!_entered)
                return;

            UnitSelectionManager.UpdateSelection();
        }
    }
}