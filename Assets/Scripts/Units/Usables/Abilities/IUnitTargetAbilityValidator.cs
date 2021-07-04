namespace RainesGames.Units.Usables.Abilities
{
    public interface IUnitTargetAbilityValidator
    {
        bool IsValid(AbsUnit parentUnit, AbsUnit targetUnit);
    }
}