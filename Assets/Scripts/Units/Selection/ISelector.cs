using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public interface ISelector
    {
        IUnit MakeSelection(Ray ray, IList<IUnit> selectables);
    }
}