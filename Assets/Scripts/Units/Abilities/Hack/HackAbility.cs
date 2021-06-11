﻿using UnityEngine;

namespace RainesGames.Units.Abilities.Hack
{
    [DisallowMultipleComponent]
    public class HackAbility : AUnitAbility
    {
        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
            _validator = new Validator(_controller);
        }

        public override void Execute(UnitController targetUnit)
        {
            if(_validator.IsValid(targetUnit))
            {
                targetUnit.HackStatusManager.Activate();
                DecrementActionPoints();
            }
        }
    }
}