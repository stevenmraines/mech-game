using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Abilities;
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

            if(activeUnit.HasAbility<MoveAbility>())
                activeUnit.GetAbility<MoveAbility>().Move(GridManager.GetCell(cellIndex));
        }

        public override void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {

        }

        public override void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {

        }
    }
}