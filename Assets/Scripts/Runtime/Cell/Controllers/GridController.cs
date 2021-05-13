using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TGS;

public class GridController : MonoBehaviour
{
    private TerrainGridSystem _terrainGridSystem;
    private List<Cell> _cells;

    void Awake()
    {
        _terrainGridSystem = FindObjectOfType<TerrainGridSystem>();
        _cells = _terrainGridSystem.cells;

        foreach(Cell cell in _cells)
        {
            GameObject gameObject = _terrainGridSystem.CellGetGameObject(cell.index);
            CellStateController stateController = gameObject.AddComponent<CellStateController>() as CellStateController;
            stateController.SetTerrainGridSystem(_terrainGridSystem);
            stateController.SetCell(cell);
        }
    }
}
