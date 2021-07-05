using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Overclock
{
    public class Validator : IUnitTargetAbilityValidator
    {
        public bool IsValid(IUnit parentUnit, IUnit targetUnit)
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