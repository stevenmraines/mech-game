using UnityEngine;

namespace RainesGames.Units.Abilities.FactoryReset
{
    // TODO abstract this class into some common interface and do the same with the ability classes and temp status manager classes
    public class Validator
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