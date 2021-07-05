namespace RainesGames.Units.Usables
{
    public interface IUnitTargetUsableValidator
    {
        bool IsValidTarget(IUnit parentUnit, IUnit targetUnit);
    }
}