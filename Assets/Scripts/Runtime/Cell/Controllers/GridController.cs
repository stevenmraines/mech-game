using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TGS;

public class GridController : MonoBehaviour
{
    private TerrainGridSystem tgs;
    private List<Cell> cells;
    
    private int columns;
    private int rows;
    private int cellLastClickedIndex;

    private void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
    {
        if(buttonIndex == 0)
            sender.CellGetGameObject(cellIndex).GetComponent<CellStateController>().HandleCellClick();
    }
    
    void OnDisable()
    {
        tgs.OnCellClick -= OnCellClick;
    }

    void Start()
    {
        tgs = FindObjectOfType<TerrainGridSystem>();
        tgs.OnCellClick += OnCellClick;

        cells = tgs.cells;
        columns = tgs.columnCount;
        rows = tgs.rowCount;

        foreach(Cell cell in cells)
        {
            GameObject go = tgs.CellGetGameObject(cell.index);
            go.AddComponent<CellStateController>();
            CellStateController _controller = go.GetComponent<CellStateController>();
            _controller.SetTerrainGridSystem(tgs);
            _controller.SetCell(cell);
        }
    }

    void Update()
    {
        Cell cell = tgs.cellHighlighted;
        int index = tgs.CellGetIndex(cell);
        cellLastClickedIndex = tgs.cellLastClickedIndex;
    }
}
