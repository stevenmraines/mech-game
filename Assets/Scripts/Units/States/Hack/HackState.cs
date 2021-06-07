using RainesGames.Units.Abilities.Hack;

namespace RainesGames.Units.States.Hack
{
    public class HackState : AUnitState
    {
        private HackAbility _ability;
        public HackAbility Ability => _ability;

        public HackState(UnitStateManager manager) : base(manager)
        {
            _ability = _manager.Controller.GetAbility<HackAbility>();
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