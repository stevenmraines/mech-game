using System;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities;
using RainesGames.Units.Usables.Abilities.FactoryReset;
using RainesGames.Units.Usables.Abilities.Hack;
using RainesGames.Units.Usables.Abilities.Overclock;
using RainesGames.Units.Usables.Abilities.ReroutePower;
using RainesGames.Units.Usables.Abilities.Underclock;

namespace RainesGames.Units.Usables
{
    public class UsableTraySort
    {
        private static Type[] _sortedUsableTypes = new Type[]
        {
            typeof(HackAbility),
            typeof(FactoryResetAbility),
            typeof(OverclockAbility),
            typeof(UnderclockAbility),
            typeof(ReroutePowerAbility)
        };

        public static Type[] SortedUsableTypes => _sortedUsableTypes;

        // TODO This whole class probably needs to go, instead make some type of "UsablesSet" for each unit class (also need to make unit classes instead of just mech classes)
        public static IList<IAbility> GetSortedAbilities(IUnit unit)
        {
            IList<IAbility> abilities = unit.GetAbilities();

            if(abilities.Count == 0)
                return abilities;

            IList<IAbility> sortedAbilities = new List<IAbility>();

            // TODO Nested loops seems kind of hacky, even if this won't hurt performance by any noticeable degree
            foreach(Type usableType in _sortedUsableTypes)
            {
                foreach(IAbility ability in abilities)
                {
                    if(usableType == ability.GetType() && !sortedAbilities.Contains(ability))
                        sortedAbilities.Add(ability);
                }
            }

            return sortedAbilities;
        }

        public static IList<IUsable> GetSortedUsables(IUnit unit)
        {
            IList<IUsable> usables = unit.GetUsables();

            if(usables.Count == 0)
                return usables;

            IList<IUsable> sortedUsables = new List<IUsable>();

            // TODO Nested loops seems kind of hacky, even if this won't hurt performance by any noticeable degree
            foreach(Type usableType in _sortedUsableTypes)
            {
                foreach(IUsable usable in usables)
                {
                    if(usableType == usable.GetType() && !sortedUsables.Contains(usable))
                        sortedUsables.Add(usable);
                }
            }

            return sortedUsables;
        }
    }
}