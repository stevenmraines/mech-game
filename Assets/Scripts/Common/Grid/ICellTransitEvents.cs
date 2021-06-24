using TGS;

namespace RainesGames.Common.Grid
{
    public interface ICellTransitEvents
    {
        void OnCellEnter(TerrainGridSystem sender, int cellIndex);
        void OnCellExit(TerrainGridSystem sender, int cellIndex);
    }
}