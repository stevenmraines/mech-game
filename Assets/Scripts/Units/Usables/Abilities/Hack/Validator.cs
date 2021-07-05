using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Hack
{
    public class Validator : IUnitTargetUsableValidator
    {
        public bool IsValidTarget(IUnit parentUnit, IUnit targetUnit)
        {
            if(targetUnit.IsHacked())
            {
                Debug.Log("Unit is already hacked");
                return false;
            }

            // TODO Maybe add functionality to hack your own units that have been hacked by the enemy, to "unhack" them
            if(parentUnit.SameTagAs(targetUnit))
            {
                Debug.Log("Cannot hack your own units");
                return false;
            }

            return true;
        }
    }
}