using UnityEngine;

namespace RainesGames.Units.Abilities.Hack
{
    public class Validator : AbsUnitAbilityValidator
    {
        public Validator(UnitController parentUnit) : base(parentUnit) { }

        public override bool IsValid(UnitController targetUnit)
        {
            if(targetUnit.IsHacked())
            {
                Debug.Log("Unit is already hacked");
                return false;
            }

            // TODO Maybe add functionality to hack your own units that have been hacked by the enemy, to "unhack" them
            if(_parentUnit.SameTagAs(targetUnit))
            {
                Debug.Log("Cannot hack your own units");
                return false;
            }

            return true;
        }
    }
}