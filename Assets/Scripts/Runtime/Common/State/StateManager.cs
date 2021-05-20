using UnityEngine;

public abstract class StateManager : MonoBehaviour, IStateManager
{
    /*
     * TODO Maybe make some abstract class that extends this, which has _current as a CombatState, UnitState, etc.
     * That class would then be extended by CombatStateManager, UnitStateManager. But then what do I call those classes?
     * Problem with that though, I'll also have to pull out the TransitionToState method, as _current won't exist in here anymore.
     */
    protected State _current;
    public State CurrentState { get => _current; }

    public abstract void NextState();

    public virtual void TransitionToState(State state)
    {
        if(_current != null)
            _current.ExitState();

        _current = state;
        _current.EnterState();
    }

    public virtual void Update()
    {
        _current.UpdateState();
    }
}
