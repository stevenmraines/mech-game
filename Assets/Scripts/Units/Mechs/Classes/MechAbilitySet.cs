using RainesGames.Units.Usables.Abilities;
using RainesGames.Units.Usables.Abilities.Move;
using RainesGames.Units.Usables.Abilities.ReroutePower;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Mechs.Classes
{
    [RequireComponent(typeof(MoveAbility))]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class MechAbilitySet : MonoBehaviour, IAbilitySet
    {
        public IList<IAbility> GetAbilities()
        {
            return new List<IAbility>()
            {
                GetComponent<MoveAbility>(),
                GetComponent<ReroutePowerAbility>()
            };
        }
    }
}
