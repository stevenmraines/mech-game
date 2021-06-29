using RainesGames.Units.Abilities.CancelReroutePower;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities.ReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CancelReroutePowerAbility))]
    public class ReroutePowerAbility : AbsAbility, ITargetlessAbility
    {
        private Validator _validator;

        protected override void Awake()
        {
            base.Awake();
            _firstAbilityCost = 1;
            _secondAbilityCost = 1;
            _validator = new Validator();
        }

        public void Execute()
        {
            if(_validator.IsValid(_controller))
            {
                _controller.DiscardPowerState();
                DecrementAbilityPoints();
            }
        }

        void Start()
        {
             _state = UnitState.REROUTE_POWER;
        }
    }
}