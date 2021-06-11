using UnityEngine;

namespace RainesGames.Units.Abilities.FactoryReset
{
    [DisallowMultipleComponent]
    public class FactoryResetAbility : AbsUnitAbility
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
                targetUnit.FactoryResetStatusManager.Activate();
                DecrementActionPoints();
            }
        }

        void Start()
        {
            _state = _controller.StateManager.FactoryReset;
        }
    }
}