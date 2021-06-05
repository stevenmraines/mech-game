using RainesGames.Grid;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class Validator
    {
        // TODO Check parentUnit's movement score against path distance
        public bool IsValid(UnitController parentUnit, int cellIndex)
        {
            if(GridManager.IsBlocked(cellIndex))
            {
                Debug.Log("Cannot move to occupied cell");
                return false;
            }

            return true;
        }
    }
}