using UnityEngine;

namespace RainesGames.Units.Abilities.ReroutePower
{
    public class Validator : AbsAbilityValidator, ITargetlessAbilityValidator
    {
        public Validator(UnitController parentUnit) : base(parentUnit) { }

        public bool IsValid()
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