using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitStateController : StateController
{
    public State idleState = new CombatUnitIdleState();
    public State activeState = new CombatUnitActiveState();
    public State destroyedState = new CombatUnitDestroyedState();
    public State targetedState = new CombatUnitTargetedState();

    void Awake()
    {
        currentState = idleState;
    }

    public override void TransitionToState(State state)
    {
        if(!typeof(CombatUnitState).IsInstanceOfType(state))
        {
            throw new ArgumentException("New state is not an instance of CombatUnitState");
        }

        base.TransitionToState(state);
    }
}
