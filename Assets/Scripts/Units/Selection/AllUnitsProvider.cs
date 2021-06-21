using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public class AllUnitsProvider : MonoBehaviour, ISelectablesProvider
    {
        public List<UnitController> GetSelectables()
        {
            return new List<UnitController>(UnitManager.Units);
        }
    }
}