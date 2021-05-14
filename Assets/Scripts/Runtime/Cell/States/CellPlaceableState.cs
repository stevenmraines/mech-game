using UnityEngine;

public class CellPlaceableState : CellState
{
    public override void EnterState(StateController stateController)
    {
        CellStateController cell = (CellStateController) stateController;
        cell.SetColor(Color.blue);
    }

    public override void ExitState(StateController stateController)
    {

    }

    public override void Update(StateController stateController)
    {
        
    }
}
