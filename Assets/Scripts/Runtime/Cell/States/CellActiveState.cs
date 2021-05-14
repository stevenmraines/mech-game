using UnityEngine;

public class CellActiveState : CellState
{
    public override void EnterState(StateController stateController)
    {
        CellStateController cell = (CellStateController) stateController;
        cell.SetColor(Color.green);
    }

    public override void ExitState(StateController stateController)
    {

    }

    public override void Update(StateController stateController)
    {
        
    }
}
