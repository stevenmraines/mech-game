using RainesGames.Grid;
using RainesGames.Units;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class CellEventHandler : States.CellEventHandler
    {
        public CellEventHandler(EnemyPlacementState enemyPlacementState) : base(enemyPlacementState) {}

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitManager.ActiveUnit == null)
                return;

            UnitManager.ActiveUnit.PositionManager.PlaceUnit(GridManager.GetCell(cellIndex));

            _state.Manager.AttemptTransition();
        }
    }
}