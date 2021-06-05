namespace RainesGames.Units.States.Idle
{
    public class IdleState : AUnitState
    {
        public IdleState(UnitStateManager manager) : base(manager) { }

        public override bool CanEnterState()
        {
            return true;
        }

        public override void EnterState()
        {
            base.EnterState();
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState() { }
    }
}