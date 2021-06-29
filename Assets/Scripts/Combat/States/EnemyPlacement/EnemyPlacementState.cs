using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class EnemyPlacementState : AbsCombatState
    {
        public delegate void StateChangeDelegate();
        public static event StateChangeDelegate OnEnterState;
        public static event StateChangeDelegate OnExitState;

        protected override void Awake()
        {
            base.Awake();
            _cellEventHandler = new CellEventHandler(this);
            _unitEventHandler = new UnitEventHandler(this);
            _stateName = "Enemy Unit Placement";
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