using System.Collections.Generic;

namespace RainesGames.Units.Abilities
{
    public interface IPathTargetAbility
    {
        void Execute(List<int> path);
    }
}