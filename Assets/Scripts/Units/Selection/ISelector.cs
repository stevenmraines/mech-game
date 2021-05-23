using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public interface ISelector
    {
        GameObject MakeSelection(Ray ray, List<GameObject> selectables);
    }
}