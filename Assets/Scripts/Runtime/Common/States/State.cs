using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void EnterState(MonoBehaviour monoBehaviour);
    public abstract bool EqualTo(State state);
    public abstract void ExitState(MonoBehaviour monoBehaviour);
    public abstract void Update(MonoBehaviour monoBehaviour);
}
