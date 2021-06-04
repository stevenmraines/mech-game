using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class CellEventHandler : ICellEvents
    {
        private EnemyPlacementState _state;

        public CellEventHandler(EnemyPlacementState enemyPlacementState)
        {
            _state = enemyPlacementState;
        }

        public void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null)
                return;

            UnitSelectionManager.ActiveUnit.PositionManager.PlaceUnit(GridManager.GetCell(cellIndex));

            _state.Manager.AttemptTransition();
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex) { }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex) { }
    }
}