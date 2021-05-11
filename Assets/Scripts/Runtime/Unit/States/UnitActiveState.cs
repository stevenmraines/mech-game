using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActiveState : UnitState
{
    public delegate void UnitActiveStateDelegate(MonoBehaviour monoBehaviour);
    public static event UnitActiveStateDelegate ActiveStateEntered;

    public override void EnterState(MonoBehaviour monoBehaviour)
    {
        ActiveStateEntered(monoBehaviour);
        Debug.Log(monoBehaviour.name + " Entering Active state");
    }

    public override void ExitState(MonoBehaviour monoBehaviour)
    {
        Debug.Log(monoBehaviour.name + " Exiting Active state");
    }

    public override void Update(MonoBehaviour monoBehaviour)
    {
        
    }
}
