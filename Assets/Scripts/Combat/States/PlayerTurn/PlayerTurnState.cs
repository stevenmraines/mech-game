using RainesGames.Grid;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class PlayerTurnState : CombatState
    {
        public delegate void StateTransitionDelegate();
        public static event StateTransitionDelegate OnEnterState;
        public static event StateTransitionDelegate OnExitState;

        protected override void Awake()
        {
            base.Awake();
            CellEventHandler = new CellEventHandler(this);
            UnitEventHandler = new UnitEventHandler(this);
            _stateName = "Player Turn";
        }

        public override void EnterState()
        {
            base.EnterState();
            OnEnterState?.Invoke();
            GridManager.EnableCellHighlight();
            GridManager.DisableTerritories();
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