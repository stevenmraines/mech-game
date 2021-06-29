using System.Collections.Generic;

namespace RainesGames.Units.Abilities
{
    public interface IPathTargetAbilityValidator
    {
        bool IsValid(AbsUnit parentUnit, List<int> path);
    }
}