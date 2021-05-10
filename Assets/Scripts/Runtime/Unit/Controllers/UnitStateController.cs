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

    public override void TransitionToState(State state)
    {
        if(!typeof(UnitState).IsInstanceOfType(state))
        {
            throw new ArgumentException("New state is not an instance of UnitState");
        }

        base.TransitionToState(state);
    }
}
