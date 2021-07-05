using System.Collections.Generic;
using TGS;

namespace RainesGames.Units.Mechs.States.Move.PathSelection
{
    public interface IUnitPathCondenser
    {
        IList<int> GetCondensedPath(IUnit unit, IList<int> path, TerrainGridSystem sender);
    }
}
