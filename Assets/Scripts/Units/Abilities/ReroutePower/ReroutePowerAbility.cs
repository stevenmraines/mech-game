using RainesGames.Units.Abilities.CancelReroutePower;
using UnityEngine;

namespace RainesGames.Units.Abilities.ReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CancelReroutePowerAbility))]
    public class ReroutePowerAbility : AbsAbility, ITargetlessAbility
    {
        private Validator _validator;

        void Awake()
        {
            _firstAbilityCost = 1;
            _secondAbilityCost = 1;
            _validator = new Validator();
        }

        public void Execute()
        {
            if(_validator.IsValid(_controller))
            {
                _controller.PowerManager.DiscardOldState();
                DecrementAbilityPoints();
            }
        }

        protected override void Start()
        {
            base.Start();
             _state = _controller.StateManager.ReroutePower;
        }
    }
}