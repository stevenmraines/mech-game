using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Selection
{
    public interface ISelectablesProvider
    {
        List<GameObject> GetSelectables();
    }
}