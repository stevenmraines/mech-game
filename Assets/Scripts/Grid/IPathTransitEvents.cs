using System.Collections.Generic;
using TGS;

namespace RainesGames.Grid
{
    public interface IPathTransitEvents
    {
        void OnPathEnter(TerrainGridSystem sender, IList<int> waypoints, IList<int> path);
        void OnPathExit(TerrainGridSystem sender, IList<int> waypoints, IList<int> path);
    }
}