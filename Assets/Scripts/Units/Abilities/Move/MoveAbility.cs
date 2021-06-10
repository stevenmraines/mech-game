namespace RainesGames.Units.Abilities.Move
{
    public class MoveAbility : AAbility
    {
        private Validator _validator;

        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
            _validator = new Validator();
        }

        public void Move(int cellIndex)
        {
            if(_validator.IsValid(_controller, cellIndex))
            {
                _controller.PositionManager.PlaceUnit(cellIndex);
                DecrementActionPoints();
            }
        }
    }
}