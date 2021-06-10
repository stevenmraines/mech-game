using TGS;

namespace RainesGames.Units.Abilities
{
    public abstract class ACellAbilityValidator : AAbilityValidator
    {
        public ACellAbilityValidator(UnitController parentUnit) : base(parentUnit) { }

        public abstract bool IsValid(Cell targetCell);
    }
}