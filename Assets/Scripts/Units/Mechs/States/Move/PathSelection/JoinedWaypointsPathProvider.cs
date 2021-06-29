using RainesGames.Common;
using RainesGames.Grid;
using System.Collections.Generic;
using TGS;
using UnityEngine;

namespace RainesGames.Units.Mechs.States.Move.PathSelection
{
    public class JoinedWaypointsPathProvider : MonoBehaviour, IUnitPathProvider
    {
        public List<int> GetPath(AbsUnit unit, List<int> waypoints, int cellIndex, TerrainGridSystem sender)
        {
            if(waypoints.Count == 0)
                return GridWrapper.FindPath(unit.GetPosition().index, cellIndex, true);

            List<int> path = GridWrapper.FindPath(unit.GetPosition().index, waypoints[0], true);

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