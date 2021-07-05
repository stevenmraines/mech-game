using RainesGames.Units;
using TGS;

namespace RainesGames.Common
{
    public interface IUnitCellTransitEvents
    {
        void OnUnitCellEnter(IUnit unit, int cellIndex, TerrainGridSystem sender);
        void OnUnitCellExit(IUnit unit, int cellIndex, TerrainGridSystem sender);
    }
}