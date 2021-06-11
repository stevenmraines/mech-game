using UnityEngine;

namespace RainesGames.Units.Abilities.Overclock
{
    [DisallowMultipleComponent]
    public class OverclockAbility : AbsUnitAbility
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
                targetUnit.ActionPointsManager.Increment();
                DecrementActionPoints();
            }
        }

        void Start()
        {
            _state = _controller.StateManager.Overclock;
        }
    }
}