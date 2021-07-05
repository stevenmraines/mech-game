using RainesGames.Units;
using TGS;

namespace RainesGames.Common
{
    public interface IUnitCellClickEvents
    {
        void OnUnitCellClick(IUnit unit, int cellIndex, TerrainGridSystem sender, int buttonIndex);
    }
}