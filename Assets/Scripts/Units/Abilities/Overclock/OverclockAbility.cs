using RainesGames.Common.Power;
using RainesGames.Units.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units.Abilities.Overclock
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class OverclockAbility : AbsAbility, IUnitAbility, IPowerContainerInteractable, IPoweredItem
    {
        public AbilityData Data;
        public int MaxPower => Data.MaxPower;
        public int MinPower => Data.MinPower;

        private Validator _validator;

        private int _power = 0;
        public int Power => _power;

        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 1;
            _secondActionCost = 1;
            _validator = new Validator(_controller);
        }

        public void AddPower(int power)
        {
            _power += power;
        }

        public void Execute(UnitController targetUnit)
        {
            if(_validator.IsValid(targetUnit))
            {
                targetUnit.ActionPointsManager.Increment();
                DecrementActionPoints();
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

        void Start()
        {
            _state = _controller.StateManager.Overclock;
        }
    }
}