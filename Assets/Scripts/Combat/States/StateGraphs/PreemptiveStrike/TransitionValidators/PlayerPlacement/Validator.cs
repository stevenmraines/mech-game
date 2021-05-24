using RainesGames.Combat.States.EnemyPlacement;
using RainesGames.Common.States;
using System;
using UnityEngine;

namespace RainesGames.Combat.States.StateGraphs.PreemptiveStrike.TransitionValidators.PlayerPlacement
{
    public class Validator : TransitionValidator<CombatState>
    {
        public override bool ValidateTransition(CombatState state)
        {
            Type stateType = state.GetType();

            Debug.Log("Boo!");

            if(stateType == typeof(EnemyPlacementState))
                return EnemyPlacement();

            return false;
        }

        bool EnemyPlacement()
        {
            Debug.Log("Yay!");
            // TODO check if all player units have been placed
            return true;
        }
    }
}