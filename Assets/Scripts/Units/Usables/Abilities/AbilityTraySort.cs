using System;
using System.Collections.Generic;
using RainesGames.Units.Abilities.FactoryReset;
using RainesGames.Units.Abilities.Hack;
using RainesGames.Units.Abilities.Overclock;
using RainesGames.Units.Abilities.ReroutePower;
using RainesGames.Units.Abilities.Underclock;

namespace RainesGames.Units.Usables.Abilities
{
    public class AbilityTraySort
    {
        private static Type[] _sortedAbilityTypes = new Type[]
        {
            typeof(HackAbility),
            typeof(FactoryResetAbility),
            typeof(OverclockAbility),
            typeof(UnderclockAbility),
            typeof(ReroutePowerAbility)
        };

        public static Type[] SortedAbilityTypes => _sortedAbilityTypes;

        public static AbsAbility[] GetSortedUnitAbilities(AbsUnit unit)
        {
            AbsAbility[] abilities = unit.GetAbilities();

            if(abilities.Length == 0)
                return abilities;

            List<AbsAbility> sortedAbilities = new List<AbsAbility>();

            // TODO Nested loops seems kind of hacky, even if this won't hurt performance by any noticeable degree
            foreach(Type abilityType in _sortedAbilityTypes)
            {
                foreach(AbsAbility ability in abilities)
                {
                    if(abilityType == ability.GetType() && !sortedAbilities.Contains(ability))
                        sortedAbilities.Add(ability);
                }
            }

            return sortedAbilities.ToArray();
        }
    }
}