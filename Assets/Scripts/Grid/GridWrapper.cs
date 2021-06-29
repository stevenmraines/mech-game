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

        public static bool IsBlocked(int cellIndex)
        {
            return IsBlocked(GetCell(cellIndex));
        }

        public static bool IsBlocked(Cell cell)
        {
            return !cell.canCross;
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

        public void OnUnitEnter(AbsUnit unit)
        {
            DisableCellHighlight();
        }

        public void OnUnitExit(AbsUnit unit)
        {
            EnableCellHighlight();
        }

        public static void SetColor(int cellIndex, Color color)
        {
            _terrainGridSystem.CellSetColor(cellIndex, color);
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