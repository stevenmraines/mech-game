using TGS;

namespace RainesGames.Units.Abilities
{
    public abstract class AbsCellAbilityValidator : AbsAbilityValidator
    {
        public AbsCellAbilityValidator(UnitController parentUnit) : base(parentUnit) { }

        public abstract bool IsValid(Cell targetCell);
    }
}