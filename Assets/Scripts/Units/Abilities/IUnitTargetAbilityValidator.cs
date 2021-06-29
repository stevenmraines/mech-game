namespace RainesGames.Units.Abilities
{
    public interface IUnitTargetAbilityValidator
    {
        bool IsValid(AbsUnit parentUnit, AbsUnit targetUnit);
    }
}