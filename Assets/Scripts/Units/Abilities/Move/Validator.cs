using RainesGames.Grid;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class Validator : AbsAbilityValidator, ICellAbilityValidator
    {
        public Validator(UnitController parentUnit) : base(parentUnit) { }

        // TODO Check parentUnit's movement score against path distance
        public bool IsValid(Cell targetCell)
        {
            if(GridManager.IsBlocked(targetCell))
            {
                Debug.Log("Cannot move to occupied cell");
                return false;
            }

            return true;
        }
    }
}