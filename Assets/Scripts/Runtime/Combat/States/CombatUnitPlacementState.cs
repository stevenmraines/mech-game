using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitPlacementState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Mech Placement state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Mech Placement state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {

    }
}
