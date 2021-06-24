using RainesGames.Units;

namespace RainesGames.Common.Units
{
    public interface IUnitTransitEvents
    {
        void OnUnitEnter(UnitController unit);
        void OnUnitExit(UnitController unit);
    }
}