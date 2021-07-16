using UnityEngine;

namespace RainesGames.Units.Usables
{
    /**
     * Basic validator that can be used for any usable which targets a player unit.
     */
    public class PlayerUnitTargetValidator : IUnitTargetUsableValidator
    {
        public bool IsValid(IUnit activeUnit, IUnit targetUnit)
        {
            if(!activeUnit.SameTeamAs(targetUnit))
            {
                Debug.Log("Cannot target enemy units");
                return false;
            }

            return true;
        }
    }
}
