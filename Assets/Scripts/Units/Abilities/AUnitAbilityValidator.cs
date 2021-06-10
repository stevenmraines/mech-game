namespace RainesGames.Units.Abilities
{
    public abstract class AUnitAbilityValidator : AAbilityValidator
    {
        public AUnitAbilityValidator(UnitController parentUnit) : base(parentUnit) { }

        public abstract bool IsValid(UnitController targetUnit);
    }
}