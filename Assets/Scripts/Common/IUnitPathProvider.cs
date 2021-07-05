using RainesGames.Units;
using System.Collections.Generic;
using TGS;

namespace RainesGames.Common
{
    public interface IUnitPathProvider
    {
        IList<int> GetPath(IUnit unit, IList<int> waypoints, int cellIndex, TerrainGridSystem sender);
    }
}