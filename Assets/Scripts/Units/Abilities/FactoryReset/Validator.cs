﻿using UnityEngine;

namespace RainesGames.Units.Abilities.FactoryReset
{
    public class Validator : AbsAbilityValidator, IUnitAbilityValidator
    {
        public Validator(UnitController parentUnit) : base(parentUnit) { }

        public bool IsValid(UnitController targetUnit)
        {
            if(_parentUnit.SameTeamAs(targetUnit))
            {
                Debug.Log("Cannot target friendly units");
                return false;
            }

            return true;
        }
    }
}