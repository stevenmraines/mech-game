using TGS;

namespace RainesGames.Combat.States
{
    public interface ICellEvents
    {
        void OnCellClick(int cellIndex, int buttonIndex);
        void OnCellEnter(TerrainGridSystem sender, int cellIndex);
        void OnCellExit(TerrainGridSystem sender, int cellIndex);
    }
}