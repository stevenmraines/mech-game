using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyTurnState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Enemy Turn state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Enemy Turn state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {

    }
}
