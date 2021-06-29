using RainesGames.Units;
using TGS;

namespace RainesGames.Common
{
    public interface IUnitCellClickEvents
    {
        void OnUnitCellClick(AbsUnit unit, int cellIndex, TerrainGridSystem sender, int buttonIndex);
    }
}