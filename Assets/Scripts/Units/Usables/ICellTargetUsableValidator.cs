using TGS;

namespace RainesGames.Units.Usables
{
    public interface ICellTargetUsableValidator
    {
        bool IsValid(IUnit activeUnit, Cell targetCell);
    }
}