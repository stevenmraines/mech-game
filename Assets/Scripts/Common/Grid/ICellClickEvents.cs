using TGS;

namespace RainesGames.Common.Grid
{
    public interface ICellClickEvents
    {
        void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex);
    }
}