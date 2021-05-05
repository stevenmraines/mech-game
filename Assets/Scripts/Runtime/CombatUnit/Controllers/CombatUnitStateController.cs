using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUnitStateController : StateController
{
    // TODO Add reference to some central CombatUnitController which gives a reference to the actual GameObject, do same with CellController, move defaultColor to that
    public Color defaultColor;
    public State idleState = new CombatUnitIdleState();
    public State activeState = new CombatUnitActiveState();
    public State destroyedState = new CombatUnitDestroyedState();
    public State targetedState = new CombatUnitTargetedState();

    void Start()
    {
        currentState = idleState;
        defaultColor = GetComponent<Renderer>().material.color;
    }

    public override void TransitionToState(State state)
    {
        if(!typeof(CombatUnitState).IsInstanceOfType(state))
        {
            throw new ArgumentException("New state is not an instance of CombatUnitState");
        }

        base.TransitionToState(state);
    }

    void OnMouseUp()
    {
        if(Input.GetMouseButtonUp(0))
        {
            CombatUnitState newState = (CombatUnitState) activeState;

            if(currentState.EqualTo(activeState))
            {
                newState = (CombatUnitState) idleState;
            }

            Debug.Log("Cube clicked");

            TransitionToState(newState);
        }
    }
}
