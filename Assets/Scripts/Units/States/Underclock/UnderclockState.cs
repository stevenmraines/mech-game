using RainesGames.Units.Abilities.Underclock;

namespace RainesGames.Units.States.Underclock
{
    public class UnderclockState : AUnitState
    {
        private UnderclockAbility _ability;
        public UnderclockAbility Ability => _ability;

        public UnderclockState(UnitStateManager manager) : base(manager)
        {
            _ability = _manager.Controller.GetAbility<UnderclockAbility>();
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