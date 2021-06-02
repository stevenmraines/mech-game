using RainesGames.Grid;
using RainesGames.Grid.Selection;
using RainesGames.Units;
using RainesGames.Units.Abilities;
using RainesGames.Units.Selection;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Combat.States.PlayerTurn
{
    public class CellEventHandler : States.CellEventHandler
    {
        // TODO if this is going to be persisted here, then we probs don't need to pass it to ColorizePath
        private List<int> _movePath;

        public CellEventHandler(PlayerTurnState playerTurnState) : base(playerTurnState) {}

        void ColorizePath(List<int> pathIndices, Color color)
        {
            foreach(int cellIndex in pathIndices)
                GridManager.TerrainGridSystem.CellSetColor(cellIndex, color);
        }

        public override void OnCellClick(int cellIndex, int buttonIndex)
        {
            if(UnitSelectionManager.ActiveUnit == null || UnitSelectionManager.ActiveUnit.IsEnemy())
                return;

            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit.HasAbility<MoveAbility>())
            {
                activeUnit.GetAbility<MoveAbility>().Move(GridManager.GetCell(cellIndex));
                ColorizePath(_movePath, GridSelectionManager.DefaultCellColor);
            }
        }

        public override void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            OnCellMouseTransit(cellIndex, GridSelectionManager.MoveCellColor);
        }

        public override void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            OnCellMouseTransit(cellIndex, GridSelectionManager.DefaultCellColor);
        }

        void OnCellMouseTransit(int cellIndex, Color cellColor)
        {
            UnitController activeUnit = UnitSelectionManager.ActiveUnit;

            if(activeUnit == null || activeUnit.IsEnemy())
                return;

            Cell activeUnitPosition = activeUnit.PositionManager.Cell;

            _movePath = GridManager.TerrainGridSystem.FindPath(activeUnitPosition.index, cellIndex);

            ColorizePath(_movePath, cellColor);
        }
    }
}