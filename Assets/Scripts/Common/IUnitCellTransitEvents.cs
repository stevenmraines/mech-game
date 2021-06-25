using RainesGames.Units;
using TGS;

namespace RainesGames.Common
{
    public interface IUnitCellTransitEvents
    {
        void OnUnitCellEnter(UnitController unit, int cellIndex, TerrainGridSystem sender);
        void OnUnitCellExit(UnitController unit, int cellIndex, TerrainGridSystem sender);
    }
}