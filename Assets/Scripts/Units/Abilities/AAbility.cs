using RainesGames.Common.Actions;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(UnitController))]
    public abstract class AAbility : MonoBehaviour, IActionCost
    {
        protected UnitController _parentUnit;

        protected int _firstActionCost;
        public int FirstActionCost => _firstActionCost;

        protected int _secondActionCost;
        public int SecondActionCost => _secondActionCost;

        protected virtual void Awake()
        {
            _parentUnit = GetComponent<UnitController>();
        }

        protected virtual void DecrementActionPoints()
        {
            _parentUnit.ActionPointsManager.Decrement(GetActionPointCost());
        }

        public virtual int GetActionPointCost()
        {
            return _parentUnit.ActionPointsManager.FirstActionSpent ? _secondActionCost : _firstActionCost;
        }
    }
}