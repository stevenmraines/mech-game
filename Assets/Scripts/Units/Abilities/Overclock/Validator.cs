using UnityEngine;

namespace RainesGames.Units.Abilities.Overclock
{
    public class Validator : AUnitAbilityValidator
    {
        public Validator(UnitController parentUnit) : base(parentUnit) { }

        public override bool IsValid(UnitController targetUnit)
        {
            if(!_parentUnit.SameTeamAs(targetUnit))
            {
                Debug.Log("Cannot target enemy units");
                return false;
            }

            return true;
        }
    }
}