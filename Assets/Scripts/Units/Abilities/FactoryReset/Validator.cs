using UnityEngine;

namespace RainesGames.Units.Abilities.FactoryReset
{
    public class Validator : IUnitTargetAbilityValidator
    {
        public bool IsValid(UnitController parentUnit, UnitController targetUnit)
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