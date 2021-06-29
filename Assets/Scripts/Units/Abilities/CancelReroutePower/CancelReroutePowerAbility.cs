using RainesGames.Units.Abilities.ReroutePower;
using RainesGames.Units.States;
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
            // TODO Get these from a ScriptableObject
            _firstAbilityCost = 0;
            _secondAbilityCost = 0;
            _showInTray = false;
        }

        public void Execute()
        {
            _controller.RevertPowerState();

            // Cancelling a power reroute costs no AP, but calling this triggers the unit state change
            DecrementAbilityPoints();
        }

        void Start()
        {
            _state = UnitState.REROUTE_POWER;
        }
    }
}