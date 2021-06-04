using RainesGames.Grid;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class PlayerPlacementState : ACombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnExitState;

        protected override void Awake()
        {
            base.Awake();
            _cellEventHandler = new CellEventHandler(this);
            _unitEventHandler = new UnitEventHandler(this);
            _stateName = "Player Unit Placement";
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