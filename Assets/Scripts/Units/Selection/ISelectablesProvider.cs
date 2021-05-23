using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public interface ISelectablesProvider
    {
        List<GameObject> GetSelectables();
    }
}