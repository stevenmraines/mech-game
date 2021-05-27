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

        void Awake()
        {
            _terrainGridSystem = GetComponent<TerrainGridSystem>();
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

        public static Cell GetCell(int index)
        {
            return _terrainGridSystem.cells[index];
        }

        public static GameObject GetCellGameObject(Cell cell)
        {
            return _terrainGridSystem.CellGetGameObject(cell.index);
        }

        public static Vector3 GetCellPosition(Cell cell)
        {
            return _terrainGridSystem.CellGetPosition(_terrainGridSystem.cells.IndexOf(cell));
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
    }
}