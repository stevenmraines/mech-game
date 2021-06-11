using TGS;

namespace RainesGames.Units.Abilities
{
    public abstract class AbsCellAbility : AbsAbility
    {
        protected AbsCellAbilityValidator _validator;

        public abstract void Execute(Cell targetCell);
    }
}