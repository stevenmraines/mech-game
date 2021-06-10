using TGS;

namespace RainesGames.Units.Abilities.Move
{
    public class MoveAbility : ACellAbility
    {
        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
            _validator = new Validator(_controller);
        }

        public override void Execute(Cell targetCell)
        {
            if(_validator.IsValid(targetCell))
            {
                _controller.PositionManager.PlaceUnit(targetCell);
                DecrementActionPoints();
            }
        }
    }
}