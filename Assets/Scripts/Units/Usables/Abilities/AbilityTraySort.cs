using System;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities.FactoryReset;
using RainesGames.Units.Usables.Abilities.Hack;
using RainesGames.Units.Usables.Abilities.Overclock;
using RainesGames.Units.Usables.Abilities.ReroutePower;
using RainesGames.Units.Usables.Abilities.Underclock;

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

        public static IList<IAbility> GetSortedUnitAbilities(IUnit unit)
        {
            IList<IAbility> abilities = unit.GetAbilities();

            if(abilities.Count == 0)
                return abilities;

            IList<IAbility> sortedAbilities = new List<IAbility>();

            // TODO Nested loops seems kind of hacky, even if this won't hurt performance by any noticeable degree
            foreach(Type abilityType in _sortedAbilityTypes)
            {
                foreach(IAbility ability in abilities)
                {
                    if(abilityType == ability.GetType() && !sortedAbilities.Contains(ability))
                        sortedAbilities.Add(ability);
                }
            }

            return sortedAbilities;
        }
    }
}