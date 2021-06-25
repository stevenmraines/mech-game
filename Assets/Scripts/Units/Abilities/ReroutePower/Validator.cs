using UnityEngine;

namespace RainesGames.Units.Abilities.ReroutePower
{
    public class Validator : ITargetlessAbilityValidator
    {
        public bool IsValid(UnitController parentUnit)
        {
            if(false)
            {
                Debug.Log("What do?");
                return false;
            }

            return true;
        }
    }
}