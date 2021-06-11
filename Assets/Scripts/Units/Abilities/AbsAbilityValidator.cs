namespace RainesGames.Units.Abilities
{
    public abstract class AbsAbilityValidator
    {
        protected UnitController _parentUnit;

        public AbsAbilityValidator(UnitController parentUnit)
        {
            _parentUnit = parentUnit;
        }
    }
}