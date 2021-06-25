using RainesGames.Units.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units.Abilities.CancelReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class CancelReroutePowerAbility : AbsAbility
    {
        void Awake()
        {
            _firstAbilityCost = 0;
            _secondAbilityCost = 0;
            _showInTray = false;
        }

        public void Execute()
        {
            _controller.PowerManager.RevertChanges();

            // Cancelling a power reroute costs no AP, but calling this triggers the unit state change
            DecrementAbilityPoints();
        }

        protected override void Start()
        {
            base.Start();
            _state = _controller.StateManager.ReroutePower;
        }
    }
}