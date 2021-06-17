﻿using TGS;
using UnityEngine;

namespace RainesGames.Units.Abilities.Move
{
    [DisallowMultipleComponent]
    public class MoveAbility : AbsAbility, ICellAbility
    {
        private Validator _validator;

        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
            _showInTray = false;
            _validator = new Validator(_controller);
        }

        public void Execute(Cell targetCell)
        {
            if(_validator.IsValid(targetCell))
            {
                _controller.PositionManager.PlaceUnit(targetCell);
                DecrementActionPoints();
            }
        }

        void Start()
        {
            _state = _controller.StateManager.Move;
        }
    }
}