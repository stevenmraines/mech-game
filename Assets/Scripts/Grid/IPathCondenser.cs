using System.Collections.Generic;
using TGS;

namespace RainesGames.Grid
{
    public interface IPathCondenser
    {
        List<int> GetCondensedPath(TerrainGridSystem sender, List<int> path);
    }
}