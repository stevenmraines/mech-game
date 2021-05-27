using RainesGames.Common.Actions;
using UnityEngine;

namespace RainesGames.Units.Actions
{
    [RequireComponent(typeof(UnitController))]
    public abstract class Action : MonoBehaviour, IActionCost
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

        protected abstract void DecrementActionPoints();
    }
}