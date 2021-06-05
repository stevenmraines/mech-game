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

        // TODO this seems to be getting called twice, causing the second call to print the debug.log statement in the MoveAbility Validator
        public void Move(int cellIndex)
        {
            if(_validator.IsValid(_parentUnit, cellIndex))
            {
                _parentUnit.PositionManager.PlaceUnit(cellIndex);
                DecrementActionPoints();
            }
        }
    }
}