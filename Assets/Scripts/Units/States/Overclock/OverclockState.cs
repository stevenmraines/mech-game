using RainesGames.Units.Abilities.Overclock;

namespace RainesGames.Units.States.Overclock
{
    public class OverclockState : AbsUnitState
    {
        private OverclockAbility _ability;
        public OverclockAbility Ability => _ability;

        public OverclockState(UnitStateManager manager) : base(manager)
        {
            _ability = _manager.Controller.GetAbility<OverclockAbility>();
             _unitEventHandler = new UnitEventHandler();
        }

        public override bool CanEnterState()
        {
            return _ability != null && _ability.ActionIsAffordable();
        }

        public override void EnterState() { }

        public override void ExitState() { }
    }
}