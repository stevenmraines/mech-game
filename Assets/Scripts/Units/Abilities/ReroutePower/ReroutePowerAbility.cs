using RainesGames.Units.Abilities.CancelReroutePower;
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
            _firstActionCost = 1;
            _secondActionCost = 1;
            _validator = new Validator(_controller);
        }

        public void Execute()
        {
            if(_validator.IsValid())
            {
                _controller.PowerManager.DiscardOldState();
                DecrementActionPoints();
            }
        }

        void Start()
        {
             _state = _controller.StateManager.ReroutePower;
        }
    }
}