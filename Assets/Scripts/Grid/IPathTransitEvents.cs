using System.Collections.Generic;
using TGS;

namespace RainesGames.Grid
{
    public interface IPathTransitEvents
    {
        void OnPathEnter(TerrainGridSystem sender, List<int> waypoints, List<int> path);
        void OnPathExit(TerrainGridSystem sender, List<int> waypoints, List<int> path);
    }
}