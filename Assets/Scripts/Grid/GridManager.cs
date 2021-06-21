using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Grid
{
    [RequireComponent(typeof(TerrainGridSystem))]
    // TODO RequireComponent GridSelectionManager?
    public class GridManager : MonoBehaviour
    {
        private static TerrainGridSystem _terrainGridSystem;
        public static TerrainGridSystem TerrainGridSystem => _terrainGridSystem;

        public enum AdjacentCellConfiguration {
            DIAGONAL_NORTH_EAST,
            DIAGONAL_NORTH_WEST,
            DIAGONAL_SOUTH_EAST,
            DIAGONAL_SOUTH_WEST,
            NOT_ADJACENT,
            SAME_COLUMN,
            SAME_ROW
        };

        static bool AdjacentCellsDiagonalNorthEast(int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == _terrainGridSystem.rowCount + 1;
        }
        
        static bool AdjacentCellsDiagonalNorthWest(int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == _terrainGridSystem.rowCount - 1;
        }

        static bool AdjacentCellsDiagonalSouthEast(int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == _terrainGridSystem.columnCount + 1;
        }

        static bool AdjacentCellsDiagonalSouthWest(int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == _terrainGridSystem.columnCount - 1;
        }

        static bool AdjacentCellsSameColumn(int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == _terrainGridSystem.rowCount;
        }

        static bool AdjacentCellsSameRow(int cellIndex1, int cellIndex2)
        {
            return Mathf.Abs(cellIndex1 - cellIndex2) == 1;
        }

        void Awake()
        {
            _terrainGridSystem = GetComponent<TerrainGridSystem>();
        }

        public static void BlockCell(int cellIndex)
        {
            BlockCell(GetCell(cellIndex));
        }

        // TODO Get rid of all these overloaded methods that exist only so I can just pass the cell object instead of the index
        public static void BlockCell(Cell cell)
        {
            _terrainGridSystem.CellSetCanCross(cell.index, false);
        }

        public static void DisableCellHighlight()
        {
            ShowCellHighlight(false);
        }
        
        public static void DisableTerritories()
        {
            ShowTerritories(false);
        }

        public static void EnableCellHighlight()
        {
            ShowCellHighlight(true);
        }
        
        public static void EnableTerritories()
        {
            ShowTerritories(true);
        }

        public static List<int> FindPath(int startCellIndex, int endCellIndex, bool unblockStartCell = false)
        {
            return FindPath(GetCell(startCellIndex), GetCell(endCellIndex), unblockStartCell);
        }

        /**
         * Return a path between two cells, optionally temporarily unblocking the
         * starting cell to allow paths which begin at some unit's current position.
         */
        public static List<int> FindPath(Cell startCell, Cell endCell, bool unblockStartCell = false)
        {
            if(unblockStartCell)
                UnblockCell(startCell);

            List<int> path = _terrainGridSystem.FindPath(startCell.index, endCell.index);

            if(unblockStartCell)
                BlockCell(startCell);

            return path;
        }

        static AdjacentCellConfiguration GetAdjacentCellConfiguration(int cellIndex1, int cellIndex2)
        {
            if(AdjacentCellsDiagonalNorthEast(cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_NORTH_EAST;

            if(AdjacentCellsDiagonalNorthWest(cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_NORTH_WEST;

            if(AdjacentCellsDiagonalSouthEast(cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_SOUTH_EAST;

            if(AdjacentCellsDiagonalSouthWest(cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.DIAGONAL_SOUTH_WEST;

            if(AdjacentCellsSameColumn(cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.SAME_COLUMN;

            if(AdjacentCellsSameRow(cellIndex1, cellIndex2))
                return AdjacentCellConfiguration.SAME_ROW;

            return AdjacentCellConfiguration.NOT_ADJACENT;
        }

        public static Cell GetCell(int index)
        {
            return _terrainGridSystem.cells[index];
        }

        public static GameObject GetCellGameObject(Cell cell)
        {
            return _terrainGridSystem.CellGetGameObject(cell.index);
        }

        public static Vector3 GetCellPosition(int cellIndex)
        {
            return _terrainGridSystem.CellGetPosition(cellIndex);
        }

        public static Vector3 GetCellPosition(Cell cell)
        {
            return GetCellPosition(cell.index);
        }

        public static List<int> GetCondensedPath(int startingCellIndex, List<int> path)
        {
            return GetCondensedPath(GetCell(startingCellIndex), path);
        }

        // TODO Move all this path stuff to some kind of GridPathManager
        public static List<int> GetCondensedPath(Cell startingCell, List<int> path)
        {
            if(path.Count < 2)
                return path;

            List<int> condensedList = new List<int>();

            AdjacentCellConfiguration cellsConfiguration = GetAdjacentCellConfiguration(startingCell.index, path[0]);

            // Something went wrong, just return the original path and get out of here
            if(cellsConfiguration == AdjacentCellConfiguration.NOT_ADJACENT)
                return path;

            AdjacentCellConfiguration cellsConfigurationPrevious;

            for(int i = 0; i < path.Count - 1; i++)
            {
                cellsConfigurationPrevious = cellsConfiguration;
                cellsConfiguration = GetAdjacentCellConfiguration(path[i], path[i + 1]);

                if(cellsConfiguration == AdjacentCellConfiguration.NOT_ADJACENT)
                    return path;

                if(cellsConfiguration != cellsConfigurationPrevious)
                    condensedList.Add(path[i]);
            }

            // Make sure the final cell is added no matter what
            if(!condensedList.Contains(path[path.Count - 1]))
                condensedList.Add(path[path.Count - 1]);

            return condensedList;
        }

        public static bool IsBlocked(int cellIndex)
        {
            return IsBlocked(GetCell(cellIndex));
        }

        public static bool IsBlocked(Cell cell)
        {
            return !cell.canCross;
        }

        static void ShowCellHighlight(bool showCellHighlight)
        {
            _terrainGridSystem.highlightMode = showCellHighlight ? HIGHLIGHT_MODE.Cells : HIGHLIGHT_MODE.None;
        }
        
        static void ShowTerritories(bool showTerritories)
        {
            _terrainGridSystem.showTerritories = showTerritories;
            _terrainGridSystem.colorizeTerritories = showTerritories;
        }

        public static void UnblockCell(int cellIndex)
        {
            UnblockCell(GetCell(cellIndex));
        }

        public static void UnblockCell(Cell cell)
        {
            _terrainGridSystem.CellSetCanCross(cell.index, true);
        }
    }
}