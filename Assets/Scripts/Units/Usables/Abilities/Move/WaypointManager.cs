using System.Collections.Generic;

namespace RainesGames.Units.Usables.Abilities.Move
{
    public class WaypointManager : IPathWaypointManager
    {
        private IList<int> _waypoints = new List<int>();

        public void AddWaypoint(int cellIndex)
        {
            _waypoints.Add(cellIndex);
        }

        public void ClearWaypoints()
        {
            _waypoints = new List<int>();
        }

        public IList<int> GetWaypoints()
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