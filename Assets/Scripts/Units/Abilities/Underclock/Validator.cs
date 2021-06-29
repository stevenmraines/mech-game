using UnityEngine;

namespace RainesGames.Units.Abilities.Underclock
{
    public class Validator : IUnitTargetAbilityValidator
    {
        public bool IsValid(AbsUnit parentUnit, AbsUnit targetUnit)
        {
            if(parentUnit.SameTeamAs(targetUnit))
            {
                Debug.Log("Cannot target friendly units");
                return false;
            }

            return true;
        }
    }
}