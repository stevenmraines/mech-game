namespace RainesGames.Units.Abilities
{
    public interface IUnitTargetAbilityValidator
    {
        bool IsValid(UnitController parentUnit, UnitController targetUnit);
    }
}