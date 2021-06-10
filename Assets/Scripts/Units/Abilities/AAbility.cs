using RainesGames.Common.Actions;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(UnitController))]
    public abstract class AAbility : MonoBehaviour, IActionCost
    {
        protected UnitController _controller;

        protected int _firstActionCost;
        public int FirstActionCost => _firstActionCost;

        protected int _secondActionCost;
        public int SecondActionCost => _secondActionCost;

        protected virtual void Awake()
        {
            _controller = GetComponent<UnitController>();
        }

        public virtual bool ActionIsAffordable()
        {
            return _controller.ActionPointsManager.ActionPoints >= GetActionPointCost();
        }

        protected virtual void DecrementActionPoints()
        {
            _controller.ActionPointsManager.Decrement(GetActionPointCost());
        }

        public virtual int GetActionPointCost()
        {
            return _controller.ActionPointsManager.FirstActionSpent ? _secondActionCost : _firstActionCost;
        }
    }
}