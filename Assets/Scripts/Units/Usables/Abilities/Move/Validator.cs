using System.Collections.Generic;
using RainesGames.Units.Mechs;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Move
{
    public class Validator : IPathTargetAbilityValidator
    {
        public bool IsValid(IUnit parentUnit, IList<int> path)
        {
            if(path.Count == 0)
            {
                Debug.Log("Cannot find path to target cell");
                return false;
            }

            if(((MechController)parentUnit).GetMovement() < path.Count)
            {
                Debug.Log("Cannot move that far");
                return false;
            }

            return true;
        }
    }
}