using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayerWonState : CombatState
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Player Won state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Player Won state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {

    }
}
