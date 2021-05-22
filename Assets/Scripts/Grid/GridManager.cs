using TGS;
using UnityEngine;

namespace RainesGames.Grid
{
    public class GridManager : MonoBehaviour
    {
        private static TerrainGridSystem _terrainGridSystem;
        public static TerrainGridSystem TerrainGridSystem { get => _terrainGridSystem; }

        void Awake()
        {
            _terrainGridSystem = GetComponent<TerrainGridSystem>();
        }

        public static void DisableCellHighlight()
        {
            HighlightCells(false);
        }

        public static void EnableCellHighlight()
        {
            HighlightCells(true);
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

        static void HighlightCells(bool highlight)
        {
            _terrainGridSystem.highlightMode = highlight ? HIGHLIGHT_MODE.Cells : HIGHLIGHT_MODE.None;
        }
    }
}