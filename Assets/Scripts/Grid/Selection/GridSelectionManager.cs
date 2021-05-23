using RainesGames.Units.Selection;
using TGS;
using UnityEngine;

namespace RainesGames.Grid.Selection
{
    public class GridSelectionManager : MonoBehaviour
    {
        public delegate void CellEventDelegate(int cellIndex, int buttonIndex);
        public static event CellEventDelegate OnCellClick;

        void CheckCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            /*
             * TGS.OnCellClick is fired even if some object sitting on top of a cell is clicked,
             * so catch it here first to make sure no units are selected. If not, then proceed.
             */
            if(buttonIndex != 0 || UnitSelectionManager.CurrentSelection != null)
                return;

            OnCellClick?.Invoke(cellIndex, buttonIndex);
        }

        void OnDisable()
        {
            GridManager.TerrainGridSystem.OnCellClick -= CheckCellClick;
        }

        void OnEnable()
        {
            GridManager.TerrainGridSystem.OnCellClick += CheckCellClick;
        }
    }
}