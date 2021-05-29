using System.Collections.Generic;

namespace RainesGames.Units.Selection
{
    public interface ISelectablesProvider
    {
        List<UnitController> GetSelectables();
    }
}