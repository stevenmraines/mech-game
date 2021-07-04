using RainesGames.Units.Usables.Abilities;
using UnityEngine;

namespace RainesGames.Units.Abilities.FactoryReset
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