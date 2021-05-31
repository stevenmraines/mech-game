using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Actions;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class CellEventHandler : States.CellEventHandler
    {
        public CellEventHandler(EnemyTurnState enemyTurnState) : base(enemyTurnState) { }

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null || UnitSelectionManager.ActiveUnit.IsPlayer())
                return;

            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit.HasAction<MoveAction>())
                activeUnit.GetAction<MoveAction>().Move(GridManager.GetCell(cellIndex));
        }

        public override void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {

        }

        public override void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {

        }
    }
}