using System;
using TGS;
using UnityEngine;

public class CellStateController : StateController
{
    private TerrainGridSystem tgs;
    private Cell cell;
    public Color defaultColor;
    public State idleState = new CellIdleState();
    public State activeState = new CellActiveState();

    void Awake()
    {
        currentState = idleState;
    }

    public Cell GetCell()
    {
        return cell;
    }

    public Color GetColor()
    {
        return tgs.CellGetColor(cell.index);
    }

    public TerrainGridSystem GetTerrainGridSystem()
    {
        return tgs;
    }
    
    public void HandleCellClick()
    {
        State newState = activeState;

        if(currentState == activeState)
            newState = idleState;

        TransitionToState(newState);
    }
    
    public void SetCell(Cell cell)
    {
        this.cell = cell;
        defaultColor = tgs.CellGetColor(cell.index);
    }

    public void SetColor(Color color)
    {
        tgs.CellSetColor(cell.index, color);
    }

    public void SetTerrainGridSystem(TerrainGridSystem tgs)
    {
        this.tgs = tgs;
    }

    public override void TransitionToState(State state)
    {
        if(!typeof(CellState).IsInstanceOfType(state))
        {
            throw new ArgumentException("New state is not an instance of CellState");
        }

        base.TransitionToState(state);
    }
}
