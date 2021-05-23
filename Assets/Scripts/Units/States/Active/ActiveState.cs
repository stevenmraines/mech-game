namespace RainesGames.Units.States
{
    public class ActiveState : UnitState
    {
        public delegate void StateTransitionDelegate(UnitController unit);
        public static event StateTransitionDelegate OnEnterState;

        public override void Awake()
        {
            base.Awake();
            StateName = "Active";
        }

        public override void EnterState()
        {
            OnEnterState?.Invoke(Manager.Controller);
        }

        public override void ExitState()
        {

        }

        public override void UpdateState()
        {

        }
    }
}