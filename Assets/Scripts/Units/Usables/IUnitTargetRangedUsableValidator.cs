namespace RainesGames.Units.Usables
{
    public interface IUnitTargetRangedUsableValidator
    {
        bool IsValid(IUnit activeUnit, IUnit targetUnit, IRangedUsable usable);
    }
}
