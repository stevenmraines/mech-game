using UnityEngine;

public abstract class StateController : MonoBehaviour
{
    public State _currentState;
    
    public virtual void TransitionToState(State state)
    {
        _currentState.ExitState(this);
        _currentState = state;
        _currentState.EnterState(this);
    }

    void Update()
    {
        _currentState.Update(this);
    }
}
