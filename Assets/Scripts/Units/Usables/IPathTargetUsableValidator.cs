using System.Collections.Generic;

namespace RainesGames.Units.Usables
{
    public interface IPathTargetUsableValidator
    {
        bool IsValid(IUnit activeUnit, IList<int> targetPath);
    }
}