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

            UnitManager.ActiveUnit.PositionManager.SetCell(GridManager.GetCell(cellIndex));

            _state.Manager.TransitionToState(_state.Manager.PlayerTurn);
        }
    }
}