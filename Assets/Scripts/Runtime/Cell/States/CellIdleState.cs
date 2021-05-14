using UnityEngine;

public class CellIdleState : CellState
{
    public override void EnterState(StateController stateController)
    {
        CellStateController cell = (CellStateController) stateController;
        cell.SetColor(cell.defaultColor);
    }

    public override void ExitState(StateController stateController)
    {

    }

    public override void Update(StateController stateController)
    {
        
    }
}
