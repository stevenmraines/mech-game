using RainesGames.Units;
using TGS;

namespace RainesGames.Common
{
    public interface IUnitCellTransitEvents
    {
        void OnUnitCellEnter(AbsUnit unit, int cellIndex, TerrainGridSystem sender);
        void OnUnitCellExit(AbsUnit unit, int cellIndex, TerrainGridSystem sender);
    }
}