using UnityEngine;

namespace RainesGames.Units.Usables.Abilities.Hack
{
    public class HackValidator : IUnitTargetUsableValidator
    {
        public bool IsValid(IUnit activeUnit, IUnit targetUnit)
        {
            if(targetUnit.IsHacked())
            {
                Debug.Log("Unit is already hacked");
                return false;
            }

            // TODO Maybe add functionality to hack your own units that have been hacked by the enemy, to "unhack" them
            if(activeUnit.SameTagAs(targetUnit))
            {
                Debug.Log("Cannot hack your own units");
                return false;
            }

            return true;
        }
    }
}