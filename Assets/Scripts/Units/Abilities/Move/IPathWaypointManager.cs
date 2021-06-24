using System.Collections.Generic;

namespace RainesGames.Units.Abilities.Move
{
    public interface IPathWaypointManager
    {
        void AddWaypoint(int cellIndex);
        void ClearWaypoints();
        List<int> GetWaypoints();
        void RemoveWaypoint(int cellIndex);
        bool WaypointIsSet(int cellIndex);
    }
}