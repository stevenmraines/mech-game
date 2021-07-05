using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public class AllUnitsProvider : MonoBehaviour, ISelectablesProvider
    {
        public IList<IUnit> GetSelectables()
        {
            return new List<IUnit>(AllUnitsManager.Units);
        }
    }
}