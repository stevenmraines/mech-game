namespace RainesGames.Units.States.Idle
{
    public class NoActionPointsState : AbsUnitState
    {
        public NoActionPointsState(UnitStateManager manager) : base(manager) { }

        public override bool CanEnterState()
        {
            return _manager.Controller.ActionPointsManager.ActionPoints == 0;
        }

        public override void EnterState() { }

        public override void ExitState() { }
    }
}