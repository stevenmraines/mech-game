using RainesGames.Units;
using TGS;

namespace RainesGames.Common.Units
{
    public interface IUnitCellClickEvents
    {
        void OnUnitCellClick(UnitController unit, int cellIndex, TerrainGridSystem sender, int buttonIndex);
    }
}