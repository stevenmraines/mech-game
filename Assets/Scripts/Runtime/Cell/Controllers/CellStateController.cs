using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TGS;

public class CellStateController : MonoBehaviour
{
    private TerrainGridSystem tgs;
    private Cell cell;
    public Color defaultColor;
    public State currentState;
    public State idleState = new CellIdleState();
    public State activeState = new CellActiveState();

    void Start()
    {
        currentState = idleState;
    }

    public void HandleCellClick()
    {
        Debug.Log("Clicked cell " + cell.index);

        State newState = activeState;

        if(currentState == activeState)
            newState = idleState;

        TransitionToState(newState);
    }

    public Cell GetCell()
    {
        return cell;
    }

    public void SetCell(Cell cell)
    {
        this.cell = cell;
        defaultColor = tgs.CellGetColor(cell.index);
    }

    public Color GetColor()
    {
        return tgs.CellGetColor(cell.index);
    }

    public void SetColor(Color color)
    {
        tgs.CellSetColor(cell.index, color);
    }

    public TerrainGridSystem GetTerrainGridSystem()
    {
        return tgs;
    }

    public void SetTerrainGridSystem(TerrainGridSystem tgs)
    {
        this.tgs = tgs;
    }

    public void TransitionToState(State newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
