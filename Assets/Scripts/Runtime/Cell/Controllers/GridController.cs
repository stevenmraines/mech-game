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

    void Awake()
    {
        tgs = FindObjectOfType<TerrainGridSystem>();

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

    private void OnCellClick(TerrainGridSystem sender, int cellIndex, int buttonIndex)
    {
        if(buttonIndex != 0)
            return;

        /*
         * Cast a ray to make sure user is clicking on a cell and
         * not some object like a mech that's standing on that cell.
         */
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Mask out everything on the terrain layer, we want to see if something else was clicked
        int combatUnitLayerIndex = LayerMask.NameToLayer("Terrain");
        int layerMask = 1 << combatUnitLayerIndex;
        layerMask = ~layerMask;

        if(Physics.Raycast(ray, Mathf.Infinity, layerMask))
            return;

        sender.CellGetGameObject(cellIndex).GetComponent<CellStateController>().HandleCellClick();
    }
    
    void OnDisable()
    {
        tgs.OnCellClick -= OnCellClick;
    }

    void OnEnable()
    {
        tgs.OnCellClick += OnCellClick;
    }

    void Update()
    {
        Cell cell = tgs.cellHighlighted;
        int index = tgs.CellGetIndex(cell);
        cellLastClickedIndex = tgs.cellLastClickedIndex;
    }
}
