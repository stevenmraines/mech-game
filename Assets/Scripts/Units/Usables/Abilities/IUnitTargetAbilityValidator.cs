namespace RainesGames.Units.Usables.Abilities
{
    public interface IUnitTargetAbilityValidator
    {
        bool IsValid(IUnit parentUnit, IUnit targetUnit);
    }
}