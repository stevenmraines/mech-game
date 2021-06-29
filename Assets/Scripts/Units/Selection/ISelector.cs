using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public interface ISelector
    {
        AbsUnit MakeSelection(Ray ray, List<AbsUnit> selectables);
    }
}