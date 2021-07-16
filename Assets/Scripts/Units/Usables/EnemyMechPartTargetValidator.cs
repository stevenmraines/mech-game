using RainesGames.Units.Mechs.MechParts;
using UnityEngine;

namespace RainesGames.Units.Usables
{
    /**
     * Basic validator that can be used for any usable which targets an enemy unit mech part.
     */
    public class EnemyMechPartTargetValidator : IMechPartTargetUsableValidator
    {
        public bool IsValid(IUnit activeUnit, IUnit targetUnit, IMechPart mechPart)
        {
            if(mechPart.GetHitPoints() == 0)
            {
                Debug.Log("Mech Part already destroyed");
                return false;
            }

            return true;
        }
    }
}
