using RainesGames.Units;
using TGS;

namespace RainesGames.Grid
{
    public interface IActiveCellClickEvents
    {
        void OnActiveCellClick(IUnit activeUnit, int cellIndex, TerrainGridSystem sender, int buttonIndex);
    }
}
