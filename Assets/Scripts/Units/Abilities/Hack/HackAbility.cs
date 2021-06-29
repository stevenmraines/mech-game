using RainesGames.Common.Power;
using RainesGames.Units.Abilities.ReroutePower;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities.Hack
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class HackAbility : AbsAbility, IUnitTargetAbility, IPowerContainerInteractable, IPoweredItem
    {
        public AbilityData Data;

        private int _power = 0;
        public int Power => _power;

        private Validator _validator;

        protected override void Awake()
        {
            base.Awake();
            _firstAbilityCost = 1;
            _secondAbilityCost = 1;
            _validator = new Validator();
        }

        public void AddPower(int power)
        {
            _power += power;
        }

        public void Execute(AbsUnit targetUnit)
        {
            if(_validator.IsValid(_controller, targetUnit))
            {
                targetUnit.Hack();
                DecrementAbilityPoints();
            }
        }

        public int GetMaxPower()
        {
            return Data.MaxPower;
        }

        public int GetMinPower()
        {
            return Data.MaxPower;
        }

        public int GetPower()
        {
            return _power;
        }

        public bool IsPowered()
        {
            return _power >= Data.MinPower;
        }

        public void RemovePower(int power)
        {
            _power -= power;
        }

        void Start()
        {
            _state = UnitState.HACK;
        }
    }
}