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
    public class CellEventHandler : ICellEvents, IEventHandlerInterruptible
    {
        private List<int> _highlightedPath;
        private List<int> _waypoints = new List<int>();
        
        void CellMouseTransit(int cellIndex, Color cellColor)
        {
            if(_waypoints.Count > 0)
                return;

            int activeUnitPosition = UnitSelectionManager.ActiveUnit.PositionManager.Cell.index;

            _highlightedPath = GridManager.FindPath(activeUnitPosition, cellIndex, true);

            ColorizePath(_highlightedPath, cellColor);
        }

        public void Cleanup()
        {
            if(_waypoints.Count > 0)
            {
                ColorizePath(_waypoints, GridSelectionManager.DefaultCellColor);
                _waypoints = new List<int>();
            }

            if(_highlightedPath != null)
                ColorizePath(_highlightedPath, GridSelectionManager.DefaultCellColor);
        }

        void ColorizePath(List<int> path, Color color)
        {
            foreach(int cellIndex in path)
                GridManager.TerrainGridSystem.CellSetColor(cellIndex, color);
        }

        List<int> GetPath(UnitController activeUnit, int cellIndex)
        {
            int activeUnitPosition = activeUnit.PositionManager.Cell.index;
            List<int> path;

            if(_waypoints.Count == 0)
            {
                path = _highlightedPath;
            }
            
            else
            {
                path = GridManager.FindPath(activeUnitPosition, _waypoints[0], true);

                for(int i = 0; i < _waypoints.Count - 1; i++)
                    path.AddRange(GridManager.FindPath(_waypoints[i], _waypoints[i + 1]));
            }

            return GridManager.GetCondensedPath(activeUnitPosition, path);
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if(GridManager.IsBlocked(cellIndex))
            {
                Cleanup();
                Debug.Log("Cannot move to occupied cell");
            }

            if(buttonIndex == 0)
            {
                if(_waypoints.Count > 0)
                    _waypoints.Add(cellIndex);

                UnitController activeUnit = UnitSelectionManager.ActiveUnit;

                List<int> path = GetPath(activeUnit, cellIndex);

                activeUnit.GetAbility<MoveAbility>().Execute(path);

                Cleanup();
            }

            if(buttonIndex == 1)
            {
                if(_waypoints.Count == 0)
                    Cleanup();

                _waypoints.Add(cellIndex);
                GridManager.TerrainGridSystem.CellSetColor(cellIndex, GridSelectionManager.MoveCellColor);
            }
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