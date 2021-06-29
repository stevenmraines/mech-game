using RainesGames.Common;
using RainesGames.Grid;
using RainesGames.Units.Mechs.States.Move.PathSelection;
using RainesGames.Units.Selection;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Mechs.States.Move
{
    public class CellEventHandler : ICellEvents
    {
        private IUnitCellEvents _moveManager;

        bool IsActiveUnitPosition(int cellIndex)
        {
            return cellIndex == UnitSelectionManager.ActiveUnit.GetPosition().index;
        }

        bool IsValidCell(int cellIndex)
        {
            return !GridWrapper.IsBlocked(cellIndex) && !IsActiveUnitPosition(cellIndex);
        }

        public void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
        {
            if(!IsValidCell(cellIndex))
            {
                Debug.Log("Cannot move to occupied cell");
                return;
            }

            if(_moveManager == null)
                _moveManager = Object.FindObjectOfType<MovePathSelectionManager>();

            _moveManager.OnUnitCellClick(UnitSelectionManager.ActiveUnit, cellIndex, sender, buttonIndex);
        }

        public void OnCellEnter(TerrainGridSystem sender, int cellIndex)
        {
            if(!IsValidCell(cellIndex))
                return;

            if(_moveManager == null)
                _moveManager = Object.FindObjectOfType<MovePathSelectionManager>();

            _moveManager.OnUnitCellEnter(UnitSelectionManager.ActiveUnit, cellIndex, sender);
        }

        public void OnCellExit(TerrainGridSystem sender, int cellIndex)
        {
            if(!IsValidCell(cellIndex))
                return;

            if(_moveManager == null)
                _moveManager = Object.FindObjectOfType<MovePathSelectionManager>();

            _moveManager.OnUnitCellExit(UnitSelectionManager.ActiveUnit, cellIndex, sender);
        }
    }
}