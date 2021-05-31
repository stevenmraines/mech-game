using RainesGames.Grid;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class CellEventHandler : States.CellEventHandler
    {
        public CellEventHandler(EnemyPlacementState enemyPlacementState) : base(enemyPlacementState) {}

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null)
                return;

            UnitSelectionManager.ActiveUnit.PositionManager.PlaceUnit(GridManager.GetCell(cellIndex));

            _state.Manager.AttemptTransition();
        }

        public override void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {

        }

        public override void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {

        }
    }
}