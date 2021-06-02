using RainesGames.Common.Actions;
using RainesGames.Units.Abilities;
using System.Collections.Generic;
using UnityEngine;

namespace RainesGames.Units.AI.GOAP.Actions
{
    public abstract class Action : MonoBehaviour, IActionCost
    {
        protected ActionPointsManager _actionPointsManager;
        protected UnitController _controller;

        protected int _firstActionCost = 1;
        public int FirstActionCost => _firstActionCost;

        protected int _secondActionCost = 1;
        public int SecondActionCost => _secondActionCost;

        protected Dictionary<string, object> _effects;
        public Dictionary<string, object> Effects => _effects;

        protected Dictionary<string, object> _preconditions;
        public Dictionary<string, object> Preconditions => _preconditions;

        protected UnitController _target;
        public UnitController Target => _target;

        protected TargetFinder _targetFinder;

        public const string CAN_ACT = "canAct";

        protected virtual void Awake()
        {
            _controller = GetComponent<UnitController>();
            _actionPointsManager = _controller.ActionPointsManager;
            _targetFinder = new TargetFinder();
            _effects = new Dictionary<string, object>();
            _preconditions = new Dictionary<string, object>();
        }

        protected int GetActionCost()
        {
            return _actionPointsManager.FirstActionSpent ? _secondActionCost : _firstActionCost;
        }

        protected bool HasEnoughActionPoints()
        {
            return _actionPointsManager.ActionPoints >= GetActionCost();
        }

        protected void DetermineTarget()
        {
            _target = _targetFinder.DetermineTarget();
        }

        public virtual void PerformAction()
        {
            DetermineTarget();
        }
    }
}