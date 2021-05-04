using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellIdleState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Idle state");
        CellStateController cell = (CellStateController) monoBehaviour;
        cell.SetColor(cell.defaultColor);
    }

    public override bool EqualTo(State state)
    {
        return this.GetType() == state.GetType();
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Idle state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
