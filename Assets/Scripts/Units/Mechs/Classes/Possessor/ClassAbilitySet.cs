using System;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities;
using RainesGames.Units.Usables.Abilities.FactoryReset;
using RainesGames.Units.Usables.Abilities.Hack;
using RainesGames.Units.Usables.Abilities.Overclock;
using RainesGames.Units.Usables.Abilities.Underclock;
using UnityEngine;

namespace RainesGames.Units.Mechs.Classes.Possessor
{
    [RequireComponent(typeof(HackAbility))]
    [RequireComponent(typeof(FactoryResetAbility))]
    [RequireComponent(typeof(OverclockAbility))]
    [RequireComponent(typeof(UnderclockAbility))]
    public class ClassAbilitySet : MonoBehaviour, IClassAbilitySet
    {
        protected IDictionary<int, Type> _sortOrder = new Dictionary<int, Type>()
        {
            { 1, typeof(HackAbility) },
            { 2, typeof(FactoryResetAbility) },
            { 3, typeof(OverclockAbility) },
            { 4, typeof(UnderclockAbility) }
        };

        public IList<IAbility> GetAbilities()
        {
            return new List<IAbility>()
            {
                GetComponent<HackAbility>(),
                GetComponent<FactoryResetAbility>(),
                GetComponent<OverclockAbility>(),
                GetComponent<UnderclockAbility>()
            };
        }

        public IDictionary<int, Type> GetSortOrder()
        {
            return _sortOrder;
        }
    }
}
