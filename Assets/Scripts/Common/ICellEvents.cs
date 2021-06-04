using TGS;

namespace RainesGames.Common
{
    public interface ICellEvents
    {
        void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex);
        void OnCellEnter(TerrainGridSystem sender, int cellIndex);
        void OnCellExit(TerrainGridSystem sender, int cellIndex);
    }
}