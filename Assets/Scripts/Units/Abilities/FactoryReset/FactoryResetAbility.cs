namespace RainesGames.Units.Abilities.FactoryReset
{
    public class FactoryResetAbility : AAbility
    {
        private Validator _validator;

        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
            _validator = new Validator();
        }

        public void Execute(UnitController targetUnit)
        {
            if(_validator.IsValid(_controller, targetUnit))
            {
                targetUnit.FactoryResetStatusManager.FactoryReset();
                DecrementActionPoints();
            }
        }
    }
}