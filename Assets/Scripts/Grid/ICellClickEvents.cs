using TGS;

namespace RainesGames.Grid
{
    public interface ICellClickEvents
    {
        void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex);
    }
}