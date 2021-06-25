using UnityEngine;

namespace RainesGames.Units.Abilities.Overclock
{
    public class Validator : IUnitTargetAbilityValidator
    {
        public bool IsValid(UnitController parentUnit, UnitController targetUnit)
        {
            if(!parentUnit.SameTeamAs(targetUnit))
            {
                Debug.Log("Cannot target enemy units");
                return false;
            }

            return true;
        }
    }
}