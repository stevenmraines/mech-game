using RainesGames.Grid;
using RainesGames.Units;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class CellEventHandler : States.CellEventHandler
    {
        public CellEventHandler(PlayerPlacementState playerPlacementState) : base(playerPlacementState) {}

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitManager.ActiveUnit == null)
                return;

            UnitManager.ActiveUnit.PositionManager.SetCell(GridManager.GetCell(cellIndex));
        }
    }
}