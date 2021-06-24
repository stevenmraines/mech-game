using RainesGames.Units;
using System.Collections.Generic;
using TGS;

namespace RainesGames.Common.Grid
{
    public interface IPathProvider
    {
        List<int> GetPath(UnitController unit, List<int> waypoints, int cellIndex, TerrainGridSystem sender);
    }
}