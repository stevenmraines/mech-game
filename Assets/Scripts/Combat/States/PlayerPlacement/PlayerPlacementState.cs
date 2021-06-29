using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class PlayerPlacementState : AbsCombatState
    {
        public delegate void StateChangeDelegate();
        public static event StateChangeDelegate OnEnterState;
        public static event StateChangeDelegate OnExitState;

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
            OnEnterState?.Invoke();
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