namespace RainesGames.Units.Usables
{
    public interface IUnitTargetUsableValidator
    {
        bool IsValid(IUnit activeUnit, IUnit targetUnit);
    }
}