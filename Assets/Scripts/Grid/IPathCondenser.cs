using System.Collections.Generic;
using TGS;

namespace RainesGames.Grid
{
    public interface IPathCondenser
    {
        IList<int> GetCondensedPath(TerrainGridSystem sender, IList<int> path);
    }
}