using System.Collections.Generic;

namespace RainesGames.Units.Usables.Abilities
{
    public interface IAbilitySet
    {
        IList<IAbility> GetAbilities();
    }
}
