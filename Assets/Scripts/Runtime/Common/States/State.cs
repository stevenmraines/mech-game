using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void EnterState(MonoBehaviour monoBehaviour);
    public abstract void ExitState(MonoBehaviour monoBehaviour);
    public abstract void Update(MonoBehaviour monoBehaviour);

    public bool EqualTo(State state)
    {
        return this.GetType() == state.GetType();
    }
}
