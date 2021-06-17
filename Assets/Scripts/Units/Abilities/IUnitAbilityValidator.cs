namespace RainesGames.Units.Abilities
{
    public interface IUnitAbilityValidator
    {
        bool IsValid(UnitController targetUnit);
    }
}