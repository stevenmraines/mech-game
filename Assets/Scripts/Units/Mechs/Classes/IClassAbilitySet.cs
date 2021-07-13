using System;
using System.Collections.Generic;
using RainesGames.Units.Usables.Abilities;

namespace RainesGames.Units.Mechs.Classes
{
    public interface IClassAbilitySet : IAbilitySet
    {
        IDictionary<int, Type> GetSortOrder();
    }
}
