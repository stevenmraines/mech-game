using RainesGames.Units;
using System.Collections.Generic;
using TGS;

namespace RainesGames.Common
{
    public interface IUnitPathProvider
    {
        List<int> GetPath(UnitController unit, List<int> waypoints, int cellIndex, TerrainGridSystem sender);
    }
}