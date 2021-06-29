using UnityEngine;

namespace RainesGames.Units.Abilities.Overclock
{
    public class Validator : IUnitTargetAbilityValidator
    {
        public bool IsValid(AbsUnit parentUnit, AbsUnit targetUnit)
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