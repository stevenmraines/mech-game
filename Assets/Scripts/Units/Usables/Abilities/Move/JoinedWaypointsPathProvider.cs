using System.Collections.Generic;
using RainesGames.Common;
using RainesGames.Grid;
using TGS;

namespace RainesGames.Units.Usables.Abilities.Move
{
    public class JoinedWaypointsPathProvider : IUnitPathProvider
    {
        public IList<int> GetPath(IUnit unit, IList<int> waypoints, int cellIndex, TerrainGridSystem sender)
        {
            if(waypoints.Count == 0)
                return GridWrapper.FindPath(unit.GetPosition().index, cellIndex, true);

            IList<int> path = GridWrapper.FindPath(unit.GetPosition().index, waypoints[0], true);

            if(waypoints.Count == 1)
            {
                ((List<int>)path).AddRange(GridWrapper.FindPath(waypoints[0], cellIndex));
                return path;
            }

            for(int i = 0; i < waypoints.Count - 1; i++)
                ((List<int>)path).AddRange(GridWrapper.FindPath(waypoints[i], waypoints[i + 1]));

            ((List<int>)path).AddRange(GridWrapper.FindPath(waypoints[waypoints.Count - 1], cellIndex));

            return path;
        }
    }
}