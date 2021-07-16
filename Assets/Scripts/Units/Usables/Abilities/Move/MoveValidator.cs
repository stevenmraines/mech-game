using System.Collections.Generic;
using RainesGames.Units.Mechs;
using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Move
{
    public class MoveValidator : IPathTargetUsableValidator
    {
        public bool IsValid(IUnit activeUnit, IList<int> targetPath)
        {
            if(targetPath.Count == 0)
            {
                Debug.Log("Cannot find path to target cell");
                return false;
            }

            if(((MechController)activeUnit).GetMovement() < targetPath.Count)
            {
                Debug.Log("Cannot move that far");
                return false;
            }

            return true;
        }
    }
}