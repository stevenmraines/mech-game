using RainesGames.Units.Abilities.FactoryReset;

namespace RainesGames.Units.States.FactoryReset
{
    public class FactoryResetState : AbsUnitState
    {
        private FactoryResetAbility _ability;
        public FactoryResetAbility Ability => _ability;

        public FactoryResetState(UnitStateManager manager) : base(manager)
        {
            _unitEventHandler = new UnitEventHandler();
            _ability = _manager.Controller.GetAbility<FactoryResetAbility>();
        }

        public override bool CanEnterState()
        {
            return _ability != null && _ability.ActionIsAffordable() && _ability.IsPowered();
        }

        public override void EnterState() { }

        public override void ExitState() { }
    }
}