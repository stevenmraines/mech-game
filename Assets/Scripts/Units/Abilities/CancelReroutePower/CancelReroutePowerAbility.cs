using RainesGames.Units.Abilities.ReroutePower;
using RainesGames.Units.States;
using UnityEngine;

namespace RainesGames.Units.Abilities.CancelReroutePower
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(ReroutePowerAbility))]
    public class CancelReroutePowerAbility : AbsAbility
    {
        public DataAbility Data;

        public override bool CanBeUsed()
        {
            return IsAffordable() && _parentUnit.HasAbility<ReroutePowerAbility>();
        }

        public void Execute()
        {
            _parentUnit.RevertPowerState();

            // Cancelling a power reroute costs no AP, but calling this triggers the unit state change
            DecrementAbilityPoints();
        }

        public override int GetFirstAbilityCost()
        {
            return Data.FirstAbilityCost;
        }

        public override int GetSecondAbilityCost()
        {
            return Data.SecondAbilityCost;
        }

        public override AudioClip GetSoundEffect()
        {
            return Data.SoundEffect;
        }

        public override UnitState GetState()
        {
            return Data.State;
        }

        public override bool ShowInTray()
        {
            return Data.ShowInTray;
        }
    }
}