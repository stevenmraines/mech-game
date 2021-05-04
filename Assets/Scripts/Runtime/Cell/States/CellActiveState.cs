using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellActiveState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Active state");
        CellStateController cell = (CellStateController) monoBehaviour;
        cell.SetColor(Color.red);
    }

    public override bool EqualTo(State state)
    {
        return this.GetType() == state.GetType();
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Active state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
