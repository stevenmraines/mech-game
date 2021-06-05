using RainesGames.Units.Abilities;
using RainesGames.Units.Abilities.Move;

namespace RainesGames.Units.States.Move
{
    public class MoveState : AUnitState
    {
        private MoveAbility _ability;
        public MoveAbility Ability => _ability;

        private ActionPointsManager _actionPointsManager;

        public MoveState(UnitStateManager manager) : base(manager)
        {
            _ability = _manager.Controller.GetAbility<MoveAbility>();
            _actionPointsManager = _manager.Controller.ActionPointsManager;
            _cellEventHandler = new CellEventHandler();
        }

        public override bool CanEnterState()
        {
            return _ability != null && _actionPointsManager.ActionPoints >= _ability.GetActionPointCost();
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