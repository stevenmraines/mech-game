using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public interface ISelector
    {
        UnitController MakeSelection(Ray ray, List<UnitController> selectables);
    }
}