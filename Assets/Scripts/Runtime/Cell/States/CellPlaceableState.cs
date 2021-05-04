using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellPlaceableState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Placeable state");
        CellStateController cell = (CellStateController) monoBehaviour;
        cell.SetColor(Color.blue);
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Placeable state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
