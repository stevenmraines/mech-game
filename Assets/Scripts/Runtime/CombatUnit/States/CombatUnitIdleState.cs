using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitIdleState : CombatUnitState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Idle state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Idle state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
