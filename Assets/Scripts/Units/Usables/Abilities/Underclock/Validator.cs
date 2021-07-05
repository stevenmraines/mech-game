using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Underclock
{
    public class Validator : IUnitTargetAbilityValidator
    {
        public bool IsValid(IUnit parentUnit, IUnit targetUnit)
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