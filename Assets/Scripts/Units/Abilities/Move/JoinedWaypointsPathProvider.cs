using RainesGames.Common.Grid;
using RainesGames.Grid;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class JoinedWaypointsPathProvider : MonoBehaviour, IPathProvider
    {
        public List<int> GetPath(UnitController unit, List<int> waypoints, int cellIndex, TerrainGridSystem sender)
        {
            if(waypoints.Count == 0)
                return GridWrapper.FindPath(unit.PositionManager.Cell.index, cellIndex, true);

            List<int> path = GridWrapper.FindPath(unit.PositionManager.Cell.index, waypoints[0], true);

            if(waypoints.Count == 1)
            {
                path.AddRange(GridWrapper.FindPath(waypoints[0], cellIndex));
                return path;
            }

            for(int i = 0; i < waypoints.Count - 1; i++)
                path.AddRange(GridWrapper.FindPath(waypoints[i], waypoints[i + 1]));

            path.AddRange(GridWrapper.FindPath(waypoints[waypoints.Count - 1], cellIndex));

            return path;
        }
    }
}