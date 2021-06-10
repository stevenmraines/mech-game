namespace RainesGames.Units.Abilities
{
    public abstract class AAbilityValidator
    {
        protected UnitController _parentUnit;

        public AAbilityValidator(UnitController parentUnit)
        {
            _parentUnit = parentUnit;
        }
    }
}