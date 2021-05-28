using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Actions;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class CellEventHandler : States.CellEventHandler
    {
        public CellEventHandler(EnemyTurnState enemyTurnState) : base(enemyTurnState) { }

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitManager.ActiveUnit == null || UnitManager.ActiveUnit.IsPlayer())
                return;

            UnitController activeUnit = UnitManager.ActiveUnit;

            if(activeUnit.HasAction<MoveAction>())
                activeUnit.GetAction<MoveAction>().Move(GridManager.GetCell(cellIndex));
        }
    }
}