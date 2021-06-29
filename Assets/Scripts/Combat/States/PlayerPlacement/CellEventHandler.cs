using RainesGames.Grid;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Combat.States.PlayerPlacement
{
    public class CellEventHandler : ICellEvents
    {
        private PlayerPlacementState _state;

        public CellEventHandler(PlayerPlacementState playerPlacementState)
        {
            _state = playerPlacementState;
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null)
                return;

            if(GridWrapper.IsBlocked(cellIndex))
                return;

            UnitSelectionManager.ActiveUnit.PlaceOnCell(cellIndex);

            _state.Manager.AttemptTransition();
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex) { }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex) { }
    }
}