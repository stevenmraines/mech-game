using System.Collections.Generic;

namespace RainesGames.Units.Abilities.Move.Path
{
    public interface IWaypointPlacementResponse
    {
        void OnPlacement(List<int> path, int cellIndex);
    }
}