using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitTargetedState : CombatUnitState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Targeted state");
        CombatUnitStateController unit = (CombatUnitStateController) monoBehaviour;
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Targeted state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
