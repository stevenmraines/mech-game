namespace RainesGames.Units.Abilities
{
    public abstract class AbsUnitAbilityValidator : AbsAbilityValidator
    {
        public AbsUnitAbilityValidator(UnitController parentUnit) : base(parentUnit) { }

        public abstract bool IsValid(UnitController targetUnit);
    }
}