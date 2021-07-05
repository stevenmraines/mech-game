using System.Collections.Generic;

namespace RainesGames.Units.Usables.Abilities
{
    public interface IPathTargetAbilityValidator
    {
        bool IsValid(IUnit parentUnit, IList<int> path);
    }
}