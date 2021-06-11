using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Overclock;
using RainesGames.Units.Abilities.Underclock;
using System;
using System.Collections.Generic;

namespace RainesGames.Units.Abilities
{
    public class AbilityTraySort
    {
        private static Type[] _sortedAbilityTypes = new Type[]
        {
            typeof(HackAbility),
            typeof(FactoryResetAbility),
            typeof(OverclockAbility),
            typeof(UnderclockAbility)
        };

        public static Type[] SortedAbilityTypes => _sortedAbilityTypes;

        public static AbsAbility[] SortAbilities(AbsAbility[] abilities)
        {
            if(abilities.Length == 0)
                return abilities;

            List<AbsAbility> sortedAbilities = new List<AbsAbility>();

            foreach(Type abilityType in _sortedAbilityTypes)
            {
                foreach(AbsAbility ability in abilities)
                {
                    if(Array.IndexOf(_sortedAbilityTypes, ability.GetType()) >= 0 && !sortedAbilities.Contains(ability))
                        sortedAbilities.Add(ability);
                }
            }

            return sortedAbilities.ToArray();
        }
    }
}