namespace RainesGames.Units.States
{
    public class ActiveState : UnitState
    {
        public delegate void StateTransitionDelegate(UnitController unit);
        public static event StateTransitionDelegate OnEnterState;

        public override void Awake()
        {
            base.Awake();
            _stateName = "Active";
        }

        public override void EnterState()
        {
            base.EnterState();
            OnEnterState?.Invoke(Manager.Controller);
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState()
        {
            
        }
    }
}