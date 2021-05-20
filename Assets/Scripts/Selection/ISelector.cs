using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Selection
{
    public interface ISelector
    {
        GameObject MakeSelection(Ray ray, List<GameObject> selectables);
    }
}