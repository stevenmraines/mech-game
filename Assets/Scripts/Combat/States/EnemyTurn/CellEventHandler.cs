using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units;
using RainesGames.Units.Abilities;
using RainesGames.Units.Selection;
using TGS;

namespace RainesGames.Combat.States.EnemyTurn
{
    public class CellEventHandler : ICellEvents
    {
        private EnemyTurnState _state;

        public CellEventHandler(EnemyTurnState enemyTurnState)
        {
            _state = enemyTurnState;
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null || UnitSelectionManager.ActiveUnit.IsPlayer())
                return;

            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit.HasAbility<MoveAbility>())
                activeUnit.GetAbility<MoveAbility>().Move(GridManager.GetCell(cellIndex));
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex) { }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex) { }
    }
}