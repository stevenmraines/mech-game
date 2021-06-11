using UnityEngine;

namespace RainesGames.Units.Abilities.Underclock
{
    [DisallowMultipleComponent]
    public class UnderclockAbility : AUnitAbility
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
                targetUnit.UnderclockStatusManager.Activate();
                DecrementActionPoints();
            }
        }
    }
}