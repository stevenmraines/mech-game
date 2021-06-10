namespace RainesGames.Units.Abilities
{
    public abstract class AUnitAbility : AAbility
    {
        protected AUnitAbilityValidator _validator;

        public abstract void Execute(UnitController targetUnit);
    }
}