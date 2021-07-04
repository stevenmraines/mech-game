using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class Validator : IPathTargetAbilityValidator
    {
        public bool IsValid(AbsUnit parentUnit, List<int> path)
        {
            if(path.Count == 0)
            {
                Debug.Log("Cannot find path to target cell");
                return false;
            }

            if(parentUnit.GetMovement() < path.Count)
            {
                Debug.Log("Cannot move that far");
                return false;
            }

            return true;
        }
    }
}