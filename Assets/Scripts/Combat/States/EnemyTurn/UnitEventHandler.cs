using RainesGames.Grid;
using RainesGames.Units;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class UnitEventHandler : States.UnitEventHandler
    {
        public UnitEventHandler(EnemyTurnState enemyTurnState) : base(enemyTurnState) { }

        public override void OnUnitClick(UnitController unit, int buttonIndex)
        {
            if(unit != UnitManager.ActiveUnit)
                UnitManager.SetActiveUnit(unit);
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