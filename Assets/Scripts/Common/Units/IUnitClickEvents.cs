using RainesGames.Units;

namespace RainesGames.Common.Units
{
    public interface IUnitClickEvents
    {
        void OnUnitClick(UnitController unit, int buttonIndex);
    }
}