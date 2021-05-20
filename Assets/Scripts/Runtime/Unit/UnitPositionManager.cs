using TGS;
using UnityEngine;

public class UnitPositionManager : MonoBehaviour
{
    private UnitController _controller;
    public UnitController Controller { get => _controller; }

    private Cell _cell;
    public Cell Cell { get => _cell; }

    void Awake()
    {
        _controller = GetComponent<UnitController>();
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

    public void SetCell(Cell cell)
    {
        _cell = cell;
        MoveUnitToCellCenter();
    }
}
