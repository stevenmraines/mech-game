using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStartState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Combat Start state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Combat Start state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {

    }
}
