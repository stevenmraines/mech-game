using RainesGames.Grid;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class EnemyPlacementState : CombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnExitState;

        protected override void Awake()
        {
            base.Awake();
            CellEventHandler = new CellEventHandler(this);
            UnitEventHandler = new UnitEventHandler(this);
            _stateName = "Enemy Unit Placement";
        }

        public override void EnterState()
        {
            base.EnterState();
            GridManager.EnableCellHighlight();
            GridManager.EnableTerritories();
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