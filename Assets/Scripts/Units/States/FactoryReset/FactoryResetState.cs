namespace RainesGames.Units.States.FactoryReset
{
    public class FactoryResetState : AbsUnitState
    {
        public FactoryResetState(UnitStateManager manager) : base(manager)
        {
            _unitEventHandler = new UnitEventHandler();
        }

        public override bool CanEnterState()
        {
            return true;
        }

        public override void EnterState() { }

        public override void ExitState() { }
    }
}