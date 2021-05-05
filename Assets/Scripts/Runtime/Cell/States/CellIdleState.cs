using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellIdleState : CellState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Idle state");
        CellStateController cell = (CellStateController) monoBehaviour;
        cell.SetColor(cell.defaultColor);
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Idle state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
