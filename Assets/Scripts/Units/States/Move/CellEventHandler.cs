using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Grid.Selection;
using RainesGames.Units.Abilities.Move;
using RainesGames.Units.Selection;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Units.States.Move
{
    public class CellEventHandler : ICellEvents
    {
        private List<int> _movePath;
        
        void CellMouseTransit(int cellIndex, Color cellColor)
        {
            int activeUnitPosition = UnitSelectionManager.ActiveUnit.PositionManager.Cell.index;

            _movePath = GridManager.FindPath(activeUnitPosition, cellIndex, true);

            ColorizePath(cellColor);
        }

        void ColorizePath(Color color)
        {
            foreach(int cellIndex in _movePath)
                GridManager.TerrainGridSystem.CellSetColor(cellIndex, color);
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            UnitSelectionManager.ActiveUnit.GetAbility<MoveAbility>().Move(cellIndex);
            ColorizePath(GridSelectionManager.DefaultCellColor);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            CellMouseTransit(cellIndex, GridSelectionManager.MoveCellColor);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            CellMouseTransit(cellIndex, GridSelectionManager.DefaultCellColor);
        }
    }
}