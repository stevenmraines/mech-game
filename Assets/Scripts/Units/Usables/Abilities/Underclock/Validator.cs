using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Underclock
{
    public class Validator : IUnitTargetUsableValidator
    {
        public bool IsValidTarget(IUnit parentUnit, IUnit targetUnit)
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