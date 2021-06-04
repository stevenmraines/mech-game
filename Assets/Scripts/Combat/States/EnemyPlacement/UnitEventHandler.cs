using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyPlacement
{
    public class UnitEventHandler : IUnitEvents
    {
        private EnemyPlacementState _state;

        public UnitEventHandler(EnemyPlacementState enemyPlacementState)
        {
            _state = enemyPlacementState;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(unit.IsEnemy())
                UnitSelectionManager.SetActiveUnit(unit);
        }

        public void OnUnitMouseEnter(UnitController unit)
        {
            GridManager.DisableCellHighlight();
        }

        public void OnUnitMouseExit(UnitController unit)
        {
            GridManager.EnableCellHighlight();
        }
    }
}