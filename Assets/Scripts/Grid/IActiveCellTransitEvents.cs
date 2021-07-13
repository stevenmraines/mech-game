using RainesGames.Units;
using TGS;

namespace RainesGames.Grid
{
    public interface IActiveCellTransitEvents
    {
        void OnActiveCellEnter(IUnit activeUnit, int cellIndex, TerrainGridSystem sender);
        void OnActiveCellExit(IUnit activeUnit, int cellIndex, TerrainGridSystem sender);
    }
}
