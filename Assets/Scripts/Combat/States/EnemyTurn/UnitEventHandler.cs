using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class UnitEventHandler : IUnitEvents
    {
        private EnemyTurnState _state;

        public UnitEventHandler(EnemyTurnState enemyTurnState)
        {
            _state = enemyTurnState;
        }

        public void OnUnitClick(UnitController unit, int buttonIndex)
        {
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