namespace RainesGames.Units.States.Idle
{
    public class NoActionPointsState : AUnitState
    {
        public NoActionPointsState(UnitStateManager manager) : base(manager) { }

        public override bool CanEnterState()
        {
            return _manager.Controller.ActionPointsManager.ActionPoints == 0;
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