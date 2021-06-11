using RainesGames.Grid;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class Validator : AbsCellAbilityValidator
    {
        public Validator(UnitController parentUnit) : base(parentUnit) { }

        // TODO Check parentUnit's movement score against path distance
        public override bool IsValid(Cell targetCell)
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