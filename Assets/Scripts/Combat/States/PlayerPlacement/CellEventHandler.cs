using RainesGames.Grid;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class CellEventHandler : States.CellEventHandler
    {
        public CellEventHandler(PlayerPlacementState playerPlacementState) : base(playerPlacementState) {}

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null)
                return;

            UnitSelectionManager.ActiveUnit.PositionManager.PlaceUnit(GridManager.GetCell(cellIndex));

            _state.Manager.AttemptTransition();
        }
    }
}