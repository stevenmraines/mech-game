using System.Collections.Generic;
using TGS;

namespace RainesGames.Units.Usables
{
    public interface IRangedUsable
    {
        IList<int> GetCellsInRange();
        int GetMaxRange();
        int GetMinRange();
        bool InRange(Cell targetCell);
    }
}
