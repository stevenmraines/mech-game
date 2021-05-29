using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Selection;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class UnitEventHandler : States.UnitEventHandler
    {
        public UnitEventHandler(EnemyTurnState enemyTurnState) : base(enemyTurnState) { }

        public override void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(unit != UnitSelectionManager.ActiveUnit)
                UnitSelectionManager.SetActiveUnit(unit);
        }

        public override void OnUnitMouseEnter(UnitController unit)
        {
            GridManager.DisableCellHighlight();
        }

        public override void OnUnitMouseExit(UnitController unit)
        {
            GridManager.EnableCellHighlight();
        }
    }
}