using RainesGames.Units.Abilities.Move;

namespace RainesGames.Units.States.Move
{
    public class MoveState : AbsUnitState
    {
        private MoveAbility _ability;
        public MoveAbility Ability => _ability;

        public MoveState(UnitStateManager manager) : base(manager)
        {
            _ability = _manager.Controller.GetAbility<MoveAbility>();
            _cellEventHandler = new CellEventHandler();
        }

        public override bool CanEnterState()
        {
            return _ability != null && _ability.ActionIsAffordable();
        }

        public override void EnterState() { }

        public override void ExitState()
        {
            ((CellEventHandler)_cellEventHandler).Cleanup();
        }
    }
}