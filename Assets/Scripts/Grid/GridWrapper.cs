using RainesGames.Combat.States.BattleStart;
using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Units;
using RainesGames.Units.Selection;
using System.Collections.Generic;
using System.Linq;
using TGS;
using UnityEngine;

namespace RainesGames.Grid
{
    [RequireComponent(typeof(TerrainGridSystem))]
    public class GridWrapper : MonoBehaviour, IUnitTransitEvents
    {
        private static TerrainGridSystem _terrainGridSystem;
        public static TerrainGridSystem TerrainGridSystem => _terrainGridSystem;


        #region MONOBEHAVIOUR METHODS
        void Awake()
        {
            _terrainGridSystem = GetComponent<TerrainGridSystem>();
        }

        void OnDisable()
        {
            BattleStartState.OnEnterState -= DisableCellHighlight;
            EnemyPlacementState.OnEnterState -= OnEnterPlacementState;
            EnemyTurnState.OnEnterState -= OnEnterTurnState;
            PlayerPlacementState.OnEnterState -= OnEnterPlacementState;
            PlayerTurnState.OnEnterState -= OnEnterTurnState;
            UnitSelectionManager.OnUnitEnter -= OnUnitEnter;
            UnitSelectionManager.OnUnitExit -= OnUnitExit;
        }

        void OnEnable()
        {
            BattleStartState.OnEnterState += DisableCellHighlight;
            EnemyPlacementState.OnEnterState += OnEnterPlacementState;
            EnemyTurnState.OnEnterState += OnEnterTurnState;
            PlayerPlacementState.OnEnterState += OnEnterPlacementState;
            PlayerTurnState.OnEnterState += OnEnterTurnState;
            UnitSelectionManager.OnUnitEnter += OnUnitEnter;
            UnitSelectionManager.OnUnitExit += OnUnitExit;
        }
        #endregion


        #region MISC METHODS
        void OnEnterPlacementState()
        {
            EnableCellHighlight();
            EnableTerritories();
        }

        void OnEnterTurnState()
        {
            EnableCellHighlight();
            DisableTerritories();
        }

        public void OnUnitEnter(IUnit unit)
        {
            DisableCellHighlight();
        }

        public void OnUnitExit(IUnit unit)
        {
            EnableCellHighlight();
        }
        #endregion


        #region CELL METHODS
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

        public static void EnableCellHighlight()
        {
            ShowCellHighlight(true);
        }

        public static Cell GetCell(int index)
        {
            return _terrainGridSystem.cells[index];
        }

        public static Cell GetCell(int row, int column)
        {
            return GetCell(_terrainGridSystem.CellGetIndex(row, column));
        }

        public static Vector3 GetCellPosition(int cellIndex)
        {
            return _terrainGridSystem.CellGetPosition(cellIndex);
        }

        public static Vector3 GetCellPosition(Cell cell)
        {
            return GetCellPosition(cell.index);
        }

        public static bool IsBlocked(int cellIndex)
        {
            return IsBlocked(GetCell(cellIndex));
        }

        public static bool IsBlocked(Cell cell)
        {
            return !cell.canCross;
        }

        public static void SetCellColor(int cellIndex, Color color)
        {
            _terrainGridSystem.CellSetColor(cellIndex, color);
        }

        static void ShowCellHighlight(bool showCellHighlight)
        {
            _terrainGridSystem.highlightMode = showCellHighlight ? HIGHLIGHT_MODE.Cells : HIGHLIGHT_MODE.None;
        }

        public static void UnblockCell(int cellIndex)
        {
            UnblockCell(GetCell(cellIndex));
        }

        public static void UnblockCell(Cell cell)
        {
            _terrainGridSystem.CellSetCanCross(cell.index, true);
        }
        #endregion


        #region CIRCLE METHODS
        /**
         * Add the indices of the cells going from a given center point,
         * offset by some X and Y values and mirrored in all 4 quadrants.
         */
        static void AddPointsMirrored(int centerX, int centerY, int x, int y, ref IList<int> cells)
        {
            int stepX = 0;

            while(stepX <= x)
            {
                // Add point to quadrant 1
                int row = centerY + y;
                int column = centerX + stepX;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to quadrant 2
                column = centerX - stepX;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to quadrant 3
                row = centerY - y;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to quadrant 4
                column = centerX + stepX;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                stepX++;
            }
        }

        /**
         * Add the indices of the cells to the right, top, left, and bottom
         * of some given center point, offset by the radius value.
         */
        static void AddPointsMirroredCenter(int centerX, int centerY, int radius, ref IList<int> cells)
        {
            int stepRadius = 0;

            while(stepRadius <= radius)
            {
                // Add point to right of center
                int row = centerY;
                int column = centerX + stepRadius;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to left of center
                column = centerX - stepRadius;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to top of center
                row = centerY + stepRadius;
                column = centerX;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to bottom of center
                row = centerY - stepRadius;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                stepRadius++;
            }
        }

        /**
         * Add the indices of the cells going from a given center point,
         * offset by some X and Y offsets (OF DIFFERING VALUES) and mirrored in all 4 quadrants.
         */
        static void AddPointsMirroredXAndYDiff(int centerX, int centerY, int x, int y, ref IList<int> cells)
        {
            int stepX = 0;

            while(stepX <= x)
            {
                // Add point to quadrant 1
                int row = centerY + stepX;
                int column = centerX + y;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to quadrant 2
                column = centerX - y;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to quadrant 3
                row = centerY - stepX;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                // Add point to quadrant 4
                column = centerX + y;

                if(InBounds(row, column))
                    cells.Add(_terrainGridSystem.CellGetIndex(row, column));

                stepX++;
            }
        }

        public static IList<int> GetFilledCircularRegion(int centerIndex, int radius)
        {
            IList<int> borderCells = new List<int>();

            int centerX = _terrainGridSystem.CellGetColumn(centerIndex);
            int centerY = _terrainGridSystem.CellGetRow(centerIndex);
            
            AddPointsMirroredCenter(centerX, centerY, radius, ref borderCells);

            /*
             * If the borderCondition is <= 0, then the next point is (x, y + 1).
             * If the borderCondition is > 0, then the next point is (x - 1, y + 1).
             */
            int borderCondition = 1 - radius;
            int x = radius;
            int y = 0;
            
            while(x > y)
            {
                y++;
                
                if(borderCondition <= 0)
                    borderCondition = borderCondition + 2 * y + 1;
                
                if(borderCondition > 0)
                {
                    x--;
                    borderCondition = borderCondition + 2 * y - 2 * x + 1;
                }
                
                if(x < y)
                    break;
                
                AddPointsMirrored(centerX, centerY, x, y, ref borderCells);
                
                if(x != y)
                    AddPointsMirroredXAndYDiff(centerX, centerY, x, y, ref borderCells);
            }

            return borderCells.Distinct().ToList();
        }

        static bool InBounds(int row, int column)
        {
            return row <= _terrainGridSystem.rowCount - 1 && row >= 0 &&
                   column <= _terrainGridSystem.columnCount - 1 && column >= 0;
        }
        #endregion


        #region PATH METHODS
        public static IList<int> FindPath(int startCellIndex, int endCellIndex, bool unblockStartCell = false)
        {
            return FindPath(GetCell(startCellIndex), GetCell(endCellIndex), unblockStartCell);
        }

        /**
         * Return a path between two cells, optionally temporarily unblocking the
         * starting cell to allow paths which begin at some unit's current position.
         */
        public static IList<int> FindPath(Cell startCell, Cell endCell, bool unblockStartCell = false)
        {
            if(unblockStartCell)
                UnblockCell(startCell);

            IList<int> path = _terrainGridSystem.FindPath(startCell.index, endCell.index);

            if(unblockStartCell)
                BlockCell(startCell);

            return path;
        }

        public static bool PathIsWithinRange(int startCellIndex, int endCellIndex, int minRange, int maxRange, bool unblockStartCell = false)
        {
            IList<int> path = FindPath(startCellIndex, endCellIndex, unblockStartCell);
            return path.Count <= maxRange && path.Count >= minRange;
        }

        public static bool PathIsWithinRange(IList<int> path, int minRange, int maxRange)
        {
            return path.Count <= maxRange && path.Count >= minRange;
        }
        #endregion


        #region TERRITORY METHODS
        public static void DisableTerritories()
        {
            ShowTerritories(false);
        }
        
        public static void EnableTerritories()
        {
            ShowTerritories(true);
        }

        static void ShowTerritories(bool showTerritories)
        {
            _terrainGridSystem.showTerritories = showTerritories;
            _terrainGridSystem.colorizeTerritories = showTerritories;
        }
        #endregion
    }
}