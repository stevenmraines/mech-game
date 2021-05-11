using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateController : StateController
{
    public State idleState = new UnitIdleState();
    public State activeState = new UnitActiveState();
    public State destroyedState = new UnitDestroyedState();
    public State targetedState = new UnitTargetedState();

    void Awake()
    {
        currentState = idleState;
    }

    private void OnActiveStateEntered(MonoBehaviour stateController)
    {
        // Can only have one unit active at a time
        if(stateController != this && currentState == activeState)
            TransitionToState(idleState);
    }

    void OnDisable()
    {
        UnitActiveState.ActiveStateEntered -= OnActiveStateEntered;
    }

    void OnEnable()
    {
        UnitActiveState.ActiveStateEntered += OnActiveStateEntered;
    }

    public override void TransitionToState(State state)
    {
        if(!typeof(UnitState).IsInstanceOfType(state))
        {
            throw new ArgumentException("New state is not an instance of UnitState");
        }

        base.TransitionToState(state);
    }
}
