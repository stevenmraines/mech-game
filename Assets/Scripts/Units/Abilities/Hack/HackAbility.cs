namespace RainesGames.Units.Abilities.Hack
{
    public class HackAbility : AAbility
    {
        private Validator _validator;

        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
            _validator = new Validator();
        }

        public void Hack(UnitController targetUnit)
        {
            if(_validator.IsValid(_parentUnit, targetUnit))
            {
                targetUnit.HackingManager.Hack();
                DecrementActionPoints();
            }
        }
    }
}