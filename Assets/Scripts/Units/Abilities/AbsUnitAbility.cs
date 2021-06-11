namespace RainesGames.Units.Abilities
{
    public abstract class AbsUnitAbility : AbsAbility
    {
        protected AbsUnitAbilityValidator _validator;

        public abstract void Execute(UnitController targetUnit);
    }
}