using RainesGames.Grid;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class PlayerPlacementState : CombatState
    {
        public delegate void PlayerPlacementStateDelegate();
        public static event PlayerPlacementStateDelegate OnStateUpdate;

        public override void Awake()
        {
            base.Awake();
            CellEventHandler = new CellEventHandler(this);
            UnitEventHandler = new UnitEventHandler(this);
            StateName = "Player Unit Placement";
        }

        public override void EnterState()
        {
            GridManager.EnableCellHighlight();
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {
            OnStateUpdate?.Invoke();
        }
    }
}