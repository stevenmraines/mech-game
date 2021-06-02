using RainesGames.Common.Actions;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(UnitController))]
    public abstract class Ability : MonoBehaviour, IActionCost
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

        protected virtual void DecrementActionPoints()
        {
            int actionPointCost = _controller.ActionPointsManager.FirstActionSpent ? _secondActionCost : _firstActionCost;
            _controller.ActionPointsManager.Decrement(actionPointCost);
        }
    }
}