using RainesGames.Units.Selection;
using TGS;
using UnityEngine;

namespace RainesGames.Grid.Selection
{
    // TODO This may not need to be a MonoBehaviour
    public class CellSelectionManager : MonoBehaviour
    {
        private static Color _defaultCellColor;
        public static Color DefaultCellColor => _defaultCellColor;

        private static Color _moveCellColor;
        public static Color MoveCellColor => _moveCellColor;

        public delegate void CellEventDelegate(TerrainGridSystem sender, int cellIndex, int buttonIndex);
        public static event CellEventDelegate OnCellClick;

        void Awake()
        {
            _defaultCellColor = new Color(0, 0, 0, 0);
            _moveCellColor = Color.blue;
        }

        void CheckCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            /*
             * TGS.OnCellClick is fired even if some object sitting on top of a cell is clicked,
             * so catch it here first to make sure no units are selected. If not, then proceed.
             */
            if(UnitSelectionManager.CurrentSelection != null)
                return;

            OnCellClick?.Invoke(sender, cellIndex, buttonIndex);
        }

        void OnDisable()
        {
            GridWrapper.TerrainGridSystem.OnCellClick -= CheckCellClick;
        }

        void OnEnable()
        {
            GridWrapper.TerrainGridSystem.OnCellClick += CheckCellClick;
        }
    }
}