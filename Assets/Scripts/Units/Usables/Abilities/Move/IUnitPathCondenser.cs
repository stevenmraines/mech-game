using System.Collections.Generic;
using TGS;

namespace RainesGames.Units.Usables.Abilities.Move
{
    public interface IUnitPathCondenser
    {
        IList<int> GetCondensedPath(IUnit unit, IList<int> path, TerrainGridSystem sender);
    }
}
