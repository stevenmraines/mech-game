using System.Collections.Generic;

namespace RainesGames.Units.Usables.Abilities
{
    public interface IPathTargetAbility
    {
        void Execute(IList<int> path);
    }
}