using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Actions;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class CellEventHandler : States.CellEventHandler
    {
        public CellEventHandler(PlayerTurnState playerTurnState) : base(playerTurnState) {}

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitManager.ActiveUnit == null || UnitManager.ActiveUnit.IsEnemy())
                return;

            UnitController activeUnit = UnitManager.ActiveUnit;

            if(activeUnit.HasAction<MoveAction>())
                activeUnit.GetAction<MoveAction>().Move(GridManager.GetCell(cellIndex));
        }
    }
}