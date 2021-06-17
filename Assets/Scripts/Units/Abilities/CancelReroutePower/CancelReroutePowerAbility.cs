using RainesGames.Units.Abilities.ReroutePower;
using UnityEngine;

namespace RainesGames.Units.Abilities.CancelReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class CancelReroutePowerAbility : AbsAbility
    {
        protected override void Awake()
        {
            base.Awake();
            _firstActionCost = 0;
            _secondActionCost = 0;
            _showInTray = false;
        }

        public void Execute()
        {
            _controller.PowerManager.RevertChanges();

            // Cancelling a power reroute costs no AP, but calling this triggers the unit state change
            DecrementActionPoints();
        }

        void Start()
        {
            _state = _controller.StateManager.ReroutePower;
        }
    }
}