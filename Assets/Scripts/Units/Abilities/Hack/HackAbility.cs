using RainesGames.Common.Power;
using UnityEngine;

namespace RainesGames.Units.Abilities.Hack
{
    [DisallowMultipleComponent]
    public class HackAbility : AbsAbility, IUnitAbility, IPowerContainerInteractable, IPoweredItem
    {
        private Validator _validator;

        private int _maxPower = 3;
        public int MaxPower => _maxPower;

        private int _minPower = 3;
        public int MinPower => _minPower;

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
                targetUnit.HackStatusManager.Activate();
                DecrementActionPoints();
            }
        }

        public bool IsPowered()
        {
            return _power >= _minPower;
        }

        public void RemovePower(int power)
        {
            _power -= power;
        }

        void Start()
        {
            _state = _controller.StateManager.Hack;
        }
    }
}