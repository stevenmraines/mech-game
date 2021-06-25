﻿using RainesGames.Common.Power;
using RainesGames.Units.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units.Abilities.Underclock
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class UnderclockAbility : AbsAbility, IUnitTargetAbility, IPowerContainerInteractable, IPoweredItem
    {
        public AbilityData Data;
        public int MaxPower => Data.MaxPower;
        public int MinPower => Data.MinPower;

        private Validator _validator;

        private int _power = 0;
        public int Power => _power;

        void Awake()
        {
            _firstAbilityCost = 1;
            _secondAbilityCost = 1;
            _validator = new Validator();
        }

        public void AddPower(int power)
        {
            _power += power;
        }

        public void Execute(UnitController targetUnit)
        {
            if(_validator.IsValid(_controller, targetUnit))
            {
                targetUnit.UnderclockStatusManager.Activate();
                DecrementAbilityPoints();
            }
        }

        public bool IsPowered()
        {
            return _power >= Data.MinPower;
        }

        public void RemovePower(int power)
        {
            _power -= power;
        }

        protected override void Start()
        {
            base.Start();
            _state = _controller.StateManager.Underclock;
        }
    }
}