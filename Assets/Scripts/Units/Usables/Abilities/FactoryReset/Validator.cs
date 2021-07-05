using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.FactoryReset
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