using UnityEngine;

public class CellAttackableState : CellState
{
    public override void EnterState(StateController stateController)
    {
        CellStateController cell = (CellStateController) stateController;
        cell.SetColor(Color.red);
    }

    public override void ExitState(StateController stateController)
    {

    }

    public override void Update(StateController stateController)
    {
        
    }
}
