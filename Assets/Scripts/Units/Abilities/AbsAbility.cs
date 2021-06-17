using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities
{
    [RequireComponent(typeof(UnitController))]
    public abstract class AbsAbility : MonoBehaviour, IAbility
    {
        protected UnitController _controller;
        public UnitController Controller => _controller;

        protected int _firstActionCost;
        public int FirstActionCost => _firstActionCost;

        protected int _secondActionCost;
        public int SecondActionCost => _secondActionCost;

        protected AbsUnitState _state;
        public AbsUnitState State => _state;

        protected bool _showInTray = true;
        public bool ShowInTray => _showInTray;

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