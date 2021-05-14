using UnityEngine;

public class CombatPlayerTurnState : CombatState
{
    public override void EnterState(StateController stateController)
    {
        
    }

    public override void ExitState(StateController stateController)
    {
        
    }

    public override void Update(StateController stateController)
    {
        SelectionManager selectionManager = GameObject.FindObjectOfType<SelectionManager>();
        selectionManager.SetSelection();
    }
}
