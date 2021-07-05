using TGS;

namespace RainesGames.Units.Usables
{
    public interface ICellTargetUsableValidator
    {
        bool IsValidTarget(IUnit parentUnit, Cell targetCell);
    }
}