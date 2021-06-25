using System.Collections.Generic;

namespace RainesGames.Units.Abilities
{
    public interface IPathTargetAbilityValidator
    {
        bool IsValid(UnitController parentUnit, List<int> path);
    }
}