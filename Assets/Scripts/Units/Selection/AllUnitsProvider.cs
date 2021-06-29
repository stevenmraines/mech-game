using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.Selection
{
    public class AllUnitsProvider : MonoBehaviour, ISelectablesProvider
    {
        public List<AbsUnit> GetSelectables()
        {
            return new List<AbsUnit>(AllUnitsManager.Units);
        }
    }
}