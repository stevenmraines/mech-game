using TGS;

namespace RainesGames.Units.Abilities
{
    public abstract class ACellAbility : AAbility
    {
        protected ACellAbilityValidator _validator;

        public abstract void Execute(Cell targetCell);
    }
}