using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayerLostState : CombatState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Player Lost state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Player Lost state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {

    }
}
