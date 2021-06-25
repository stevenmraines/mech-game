using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class Validator : IPathTargetAbilityValidator
    {
        // TODO Check parentUnit's movement score against path distance
        public bool IsValid(UnitController parentUnit, List<int> path)
        {
            if(path.Count == 0)
            {
                Debug.Log("Cannot find path to target cell");
                return false;
            }

            return true;
        }
    }
}