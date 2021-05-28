using RainesGames.Grid;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class EnemyTurnState : CombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnEnterState;

        protected override void Awake()
        {
            base.Awake();
            CellEventHandler = new CellEventHandler(this);
            UnitEventHandler = new UnitEventHandler(this);
            _stateName = "Enemy Turn";
        }

        public override void EnterState()
        {
            base.EnterState();
            OnEnterState?.Invoke();
            GridManager.EnableCellHighlight();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState()
        {
            UnitSelectionManager.UpdateSelection();
        }
    }
}