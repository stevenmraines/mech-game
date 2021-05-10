using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActiveState : UnitState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Active state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Active state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
