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

        void MoveUnitToCellCenter()
        {
            Vector3 cellPosition = GridManager.GetCellPosition(_cell);

            _controller.gameObject.transform.position = new Vector3(
                cellPosition.x,
                _controller.gameObject.transform.position.y,
                cellPosition.z
            );
        }

        public void PlaceUnit(int newPositionIndex)
        {
            PlaceUnit(GridManager.GetCell(newPositionIndex));
        }

        public void PlaceUnit(Cell newPosition)
        {
            Cell oldPosition = _cell;
            _cell = newPosition;
            MoveUnitToCellCenter();
            UpdateCellsBlocking(oldPosition, newPosition);
        }

        void UpdateCellsBlocking(Cell oldPosition, Cell newPosition)
        {
            if(oldPosition != null)
                GridManager.UnblockCell(oldPosition);

            GridManager.BlockCell(newPosition);
        }
    }
}