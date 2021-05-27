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
            StateName = "Player Turn";
        }

        public override void EnterState()
        {
            OnEnterState?.Invoke();
            GridManager.EnableCellHighlight();
            GridManager.DisableTerritories();
        }

        public override void ExitState()
        {
            OnExitState?.Invoke();
        }

        public override void UpdateState()
        {
            UnitSelectionManager.UpdateSelection();
        }
    }
}