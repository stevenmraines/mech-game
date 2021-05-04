using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayerTurnState : State
{
    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Entering Player Turn state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log("Exiting Player Turn state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {

    }
}
