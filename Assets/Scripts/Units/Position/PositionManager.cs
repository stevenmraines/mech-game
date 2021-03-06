using RainesGames.Grid;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Position
{
    public class PositionManager
    {
        private Cell _position;

        public Cell GetPosition()
        {
            return _position;
        }

        public bool IsPlaced()
        {
            return _position != null;
        }

        void MoveUnitToCellCenter(Transform transform)
        {
            Vector3 position = GridWrapper.GetCellPosition(_position);

            Vector3 newPosition = new Vector3(
                position.x,
                transform.position.y,
                position.z
            );

            transform.position = newPosition;
        }

        public void PlaceOnPosition(Transform transform, int cellIndex)
        {
            SetPosition(cellIndex);
            MoveUnitToCellCenter(transform);
        }

        public void SetPosition(int cellIndex)
        {
            Cell oldPosition = _position;
            _position = GridWrapper.GetCell(cellIndex);
            UpdateCellsBlocking(oldPosition, _position);
        }

        void UpdateCellsBlocking(Cell oldPosition, Cell newPosition)
        {
            if(oldPosition != null)
                GridWrapper.UnblockCell(oldPosition);

            GridWrapper.BlockCell(newPosition);
        }
    }
}