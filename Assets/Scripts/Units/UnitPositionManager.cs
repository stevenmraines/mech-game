using RainesGames.Grid;
using TGS;
using UnityEngine;

namespace RainesGames.Units
{
    public class UnitPositionManager
    {
        private Cell _cell;
        public Cell Cell => _cell;

        private UnitController _controller;
        public UnitController Controller => _controller;

        public bool IsPlaced => _cell != null;

        public UnitPositionManager(UnitController controller)
        {
            _controller = controller;
        }

        public static bool CellIsOccupied(Cell cell)
        {
            foreach(UnitController unit in UnitManager.Units)
            {
                if(unit.PositionManager.Cell == cell)
                    return true;
            }

            return false;
        }

        void MoveUnitToCellCenter()
        {
            Vector3 cellPosition = GridManager.GetCellPosition(_cell);

            _controller.gameObject.transform.position = new Vector3(
                cellPosition.x,
                _controller.gameObject.transform.position.y,
                cellPosition.z
            );
        }

        public void PlaceUnit(Cell cell)
        {
            SetCell(cell);
            MoveUnitToCellCenter();
        }

        public void SetCell(Cell cell)
        {
            _cell = cell;
        }
    }
}