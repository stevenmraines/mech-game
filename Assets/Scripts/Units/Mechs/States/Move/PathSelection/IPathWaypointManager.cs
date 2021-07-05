using System.Collections.Generic;

namespace RainesGames.Units.Mechs.States.Move.PathSelection
{
    public interface IPathWaypointManager
    {
        void AddWaypoint(int cellIndex);
        void ClearWaypoints();
        IList<int> GetWaypoints();
        void RemoveWaypoint(int cellIndex);
        bool WaypointIsSet(int cellIndex);
    }
}