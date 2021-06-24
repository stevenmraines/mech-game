using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    public class WaypointManager : MonoBehaviour, IPathWaypointManager
    {
        private List<int> _waypoints = new List<int>();

        public void AddWaypoint(int cellIndex)
        {
            _waypoints.Add(cellIndex);
        }

        public void ClearWaypoints()
        {
            _waypoints = new List<int>();
        }

        public List<int> GetWaypoints()
        {
            return _waypoints;
        }

        public void RemoveWaypoint(int cellIndex)
        {
            _waypoints.Remove(cellIndex);
        }

        public bool WaypointIsSet(int cellIndex)
        {
            return _waypoints.Contains(cellIndex);
        }
    }
}