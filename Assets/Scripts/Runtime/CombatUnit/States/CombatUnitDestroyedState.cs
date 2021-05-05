using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitDestroyedState : CombatUnitState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Destroyed state");
        CombatUnitStateController unit = (CombatUnitStateController) monoBehaviour;
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Destroyed state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
