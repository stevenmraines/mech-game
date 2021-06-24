using RainesGames.Units;
using TGS;

namespace RainesGames.Common.Units
{
    public interface IUnitCellTransitEvents
    {
        void OnUnitCellEnter(UnitController unit, int cellIndex, TerrainGridSystem sender);
        void OnUnitCellExit(UnitController unit, int cellIndex, TerrainGridSystem sender);
    }
}