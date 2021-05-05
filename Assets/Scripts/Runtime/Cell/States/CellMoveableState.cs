using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMoveableState : CellState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Moveable state");
        CellStateController cell = (CellStateController) monoBehaviour;
        cell.SetColor(Color.blue);
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Moveable state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
