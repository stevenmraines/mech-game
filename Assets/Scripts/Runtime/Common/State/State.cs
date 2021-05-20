using UnityEngine;

public abstract class State : MonoBehaviour, IState
{
    public string StateName { get; set; }

    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
}
