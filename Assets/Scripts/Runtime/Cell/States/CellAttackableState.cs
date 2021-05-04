using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAttackableState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Attackable state");
        CellStateController cell = (CellStateController) monoBehaviour;
        cell.SetColor(Color.red);
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Attackable state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
