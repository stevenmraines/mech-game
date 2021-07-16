using System.Collections.Generic;

namespace RainesGames.Units.Usables
{
    public interface IPathTargetUsable
    {
        void Use(IList<int> targetPath);
    }
}