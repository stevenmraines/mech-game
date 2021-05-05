using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponIdleState : WeaponState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Weapon Idle state");
        WeaponStateController weapon = (WeaponStateController) monoBehaviour;
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Weapon Idle state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
