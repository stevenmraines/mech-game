using System.Collections.Generic;

namespace RainesGames.Units.Usables
{
    public interface IPathTargetUsableValidator
    {
        bool IsValidTarget(IUnit parentUnit, IList<int> path);
    }
}