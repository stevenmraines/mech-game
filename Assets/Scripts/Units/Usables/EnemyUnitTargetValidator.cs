using UnityEngine;

namespace RainesGames.Units.Usables
{
    /**
     * Basic validator that can be used for any usable which targets an enemy unit.
     */
    public class EnemyUnitTargetValidator : IUnitTargetUsableValidator
    {
        public bool IsValid(IUnit activeUnit, IUnit targetUnit)
        {
            if(activeUnit.SameTeamAs(targetUnit))
            {
                Debug.Log("Cannot target friendly units");
                return false;
            }

            return true;
        }
    }
}
