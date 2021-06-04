using RainesGames.Units;

namespace RainesGames.Common
{
    public interface IUnitEvents
    {
        void OnUnitClick(UnitController unit, int buttonIndex);
        void OnUnitMouseEnter(UnitController unit);
        void OnUnitMouseExit(UnitController unit);
    }
}