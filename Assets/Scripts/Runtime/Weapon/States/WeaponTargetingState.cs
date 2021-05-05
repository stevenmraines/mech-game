using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTargetingState : WeaponState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Weapon Targeting state");
        WeaponStateController weapon = (WeaponStateController) monoBehaviour;
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Weapon Targeting state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
