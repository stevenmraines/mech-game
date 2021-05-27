using TGS;

namespace RainesGames.Units.Actions
{
    public class MoveAction : Action
    {
        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
        }

        protected override void DecrementActionPoints()
        {
            int actionPointCost = _controller.ActionPointsManager.FirstActionSpent ? _secondActionCost : _firstActionCost;
            _controller.ActionPointsManager.Decrement(actionPointCost);
        }

        public void Move(Cell cell)
        {
            if(_controller.ActionPointsManager.ActionPoints == 0)
                return;

            _controller.PositionManager.PlaceUnit(cell);
            DecrementActionPoints();
        }
    }
}