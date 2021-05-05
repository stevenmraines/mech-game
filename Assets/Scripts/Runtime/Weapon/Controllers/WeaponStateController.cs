using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateController : StateController
{
    public State idleState = new WeaponIdleState();
    public State targetingState = new WeaponTargetingState();

    public override void TransitionToState(State state)
    {
        if(!typeof(WeaponState).IsInstanceOfType(state))
        {
            throw new ArgumentException("New state is not an instance of WeaponState");
        }

        base.TransitionToState(state);
    }
}
