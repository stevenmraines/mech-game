using RainesGames.Combat.States.BattleStart;
using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Combat.States.EnemyTurn;
using RainesGames.Combat.States.PlayerPlacement;
using RainesGames.Combat.States.PlayerTurn;
using RainesGames.Units;
using RainesGames.Units.Selection;
using System.Collections.Generic;
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